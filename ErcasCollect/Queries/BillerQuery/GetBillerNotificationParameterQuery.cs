using AutoMapper;
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

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetBillerNotificationParameterQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;
        public GetBillerNotificationParameterQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetBillerNotificationParameterQueryHandler : IRequestHandler<GetBillerNotificationParameterQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<BillerNotification> _billerNotificationRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;

            public GetBillerNotificationParameterQueryHandler(IGenericRepository<Biller> billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode, 
                
                IGenericRepository<BillerNotification> billerNotificationRepository)
            {
                _billerRepository = billerRepository;

                this.mapper = mapper;

                _responseCode = responseCode.Value;

                _billerNotificationRepository = billerNotificationRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerNotificationParameterQuery request, CancellationToken cancellationToken)
            {
                var biller = await _billerRepository.FindSingleInclude(x => x.ReferenceKey == request._billerId, x => x.BillerNotifications);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid billlerId", _responseCode.NotFound, false);

                var billerValidationParameter = biller.BillerNotifications.Select(mapper.Map<BillerNotification, BillerNotificationDto>);

                return ResponseGenerator.Response("Successfull", _responseCode.OK, true, billerValidationParameter);
            }
        }
    }
}
