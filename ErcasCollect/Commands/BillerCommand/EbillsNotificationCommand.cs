using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.BillerCommand
{
    public class EbillsNotificationCommand : IRequest<SuccessfulResponse>
    {
        public EbillsNotificationDto ebillsNotificationDto { get; set; }

        public class EbillsNotificationCommandHandler : IRequestHandler<EbillsNotificationCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<BillerNotification> _billerNotificationRepository;

            private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

            private readonly ResponseCode _responseCode;

            public EbillsNotificationCommandHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<BillerNotification> billerNotificationRepository, 
                
                IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository;

                _billerNotificationRepository = billerNotificationRepository;

                _billerEbillsProductRepository = billerEbillsProductRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(EbillsNotificationCommand request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.ebillsNotificationDto.BillerId);

                var ebillsProductId = _billerEbillsProductRepository.FindFirst(x => x.ReferenceKey == request.ebillsNotificationDto.BillerProductId).Id;

                var ebillsNotification = new BillerNotification()
                {
                    BillerEbillsProductId = ebillsProductId,

                    BillerId = biller.Id,

                    NotificationName = request.ebillsNotificationDto.NotificationField,

                    CreatedDate = DateTime.UtcNow
                };

                var savedEbillsNotification = await _billerNotificationRepository.Add(ebillsNotification);

                await _billerNotificationRepository.CommitAsync();

                return ResponseGenerator.Response("Created Successful", _responseCode.Created, true, request.ebillsNotificationDto);
            }
        }
    }
}
