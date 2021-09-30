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
    public class GetAllBillerEbillsProduct : IRequest<SuccessfulResponse>
    {
        public string Id { get; set; }

        public class GetAllBillerEbillsProductQueryHandler : IRequestHandler<GetAllBillerEbillsProduct, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<EbillsProduct> _ebillsProductRepository;

            public GetAllBillerEbillsProductQueryHandler(IOptions<ResponseCode> responseCode, IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository,

                IGenericRepository<Biller> billerRepository, IGenericRepository<EbillsProduct> ebillsProductRepository)
            {
                _responseCode = responseCode.Value;

                _billerEbillsProductRepository = billerEbillsProductRepository;

                _billerRepository = billerRepository;

                _ebillsProductRepository = ebillsProductRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllBillerEbillsProduct request, CancellationToken cancellationToken)
            {
                List<BillerEbillsProductDto> billerList = new List<BillerEbillsProductDto>();

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.Id);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid billerId", _responseCode.NotFound, false);
                }

                var ebillsProduct = _billerEbillsProductRepository.Find(x => x.BillerId == biller.Id).ToList();

                foreach (var item in ebillsProduct)
                {
                    var listofProduct = new BillerEbillsProductDto()
                    {
                        ReferenceKey = item.ReferenceKey,

                        EbillsProductName = GetEbillsProduct((int)item.EbillsProductId)
                    };

                    billerList.Add(listofProduct);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, billerList);

            }

            private string GetEbillsProduct(int id)
            {
                var ebillsProduct = _ebillsProductRepository.FindFirst(x => x.Id == id);

                if (ebillsProduct == null)

                    return null;

                return ebillsProduct.ProductName;
            }
        }
    }
}
