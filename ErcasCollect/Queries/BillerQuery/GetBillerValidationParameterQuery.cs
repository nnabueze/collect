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
    public class GetBillerValidationParameterQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetBillerValidationParameterQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetBillerValidationParameterQueryHandler : IRequestHandler<GetBillerValidationParameterQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<BillerValidation> _billerValidationRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode _responseCode;

            public GetBillerValidationParameterQueryHandler(IGenericRepository<BillerValidation> billerValidationRepository, IMapper mapper, 
                
                IOptions<ResponseCode> responseCode, IGenericRepository<Biller> billerRepository)
            {
                _billerValidationRepository = billerValidationRepository;

                this.mapper = mapper;

                _responseCode = responseCode.Value;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerValidationParameterQuery request, CancellationToken cancellationToken)
            {
                var biller = await _billerRepository.FindSingleInclude(x => x.ReferenceKey == request._billerId, x => x.BillerValidations);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid billlerId", _responseCode.NotFound, false);

                var billerValidationParameter = biller.BillerValidations.Select(mapper.Map<BillerValidation, EbillsBillerValidationDto>);

                return ResponseGenerator.Response("Successfull", _responseCode.OK, true, billerValidationParameter);
            }
        }
    }
}
