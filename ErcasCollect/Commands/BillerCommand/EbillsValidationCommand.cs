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
    public class EbillsValidationCommand : IRequest<SuccessfulResponse>
    {
        public EbillsValidationDto ebillsValidationDto { get; set; }

        public class EbillsValidationCommandHandler : IRequestHandler<EbillsValidationCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<BillerValidation> _billerValidationRepository;

            private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

            private readonly ResponseCode _responseCode;

            public EbillsValidationCommandHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<BillerValidation> billerValidationRepository, 
                
                IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository;

                _billerValidationRepository = billerValidationRepository;

                _billerEbillsProductRepository = billerEbillsProductRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(EbillsValidationCommand request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.ebillsValidationDto.BillerId);

                var ebillsProductId = _billerEbillsProductRepository.FindFirst(x => x.ReferenceKey == request.ebillsValidationDto.BillerProductId).Id;

                foreach (var item in request.ebillsValidationDto.ValidationFields)
                {
                    var ebillsValidation = new BillerValidation()
                    {
                        BillerEbillsProductId = ebillsProductId,

                        BillerId = biller.Id,

                        ValidationName = item.ValidationField,

                        VaidationStep = item.ValidationStep,

                        CreatedDate = DateTime.UtcNow
                    };

                    var savedEbillsValidation = await _billerValidationRepository.Add(ebillsValidation);
                }

                await _billerValidationRepository.CommitAsync();

                return ResponseGenerator.Response("Created Successful", _responseCode.Created, true, request.ebillsValidationDto);
            }
        }
    }
}
