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
    public class GetAllBillerEbillsProduct : IRequest<SuccessfulResponse>
    {
        public string Id { get; set; }

        public class GetAllBillerEbillsProductQueryHandler : IRequestHandler<GetAllBillerEbillsProduct, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            public GetAllBillerEbillsProductQueryHandler(IOptions<ResponseCode> responseCode, IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository, 
                
                IGenericRepository<Biller> billerRepository)
            {
                _responseCode = responseCode.Value;

                _billerEbillsProductRepository = billerEbillsProductRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllBillerEbillsProduct request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.Id);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid billerId", _responseCode.NotFound, false);
                }

                var ebillsProduct = await _billerEbillsProductRepository.FindAllInclude(x => x.BillerId == biller.Id);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, ebillsProduct);

            }
        }
    }
}
