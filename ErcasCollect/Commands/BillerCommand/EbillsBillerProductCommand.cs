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
    public class EbillsBillerProductCommand : IRequest<SuccessfulResponse>
    {
        public EbillsBillerProductDto ebillsBillerProductDto { get; set; }
        public class EbillsBillerProductCommandHandler : IRequestHandler<EbillsBillerProductCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<BillerEbillsProduct> _billerEbillsProductRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            public EbillsBillerProductCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<BillerEbillsProduct> billerEbillsProductRepository,
                
                IGenericRepository<Biller> billerRepository)
            {
                _responseCode = responseCode.Value;

                _billerEbillsProductRepository = billerEbillsProductRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(EbillsBillerProductCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.ebillsBillerProductDto.BillerId);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                var ebillProduct = new BillerEbillsProduct()
                {
                    BillerId = biller.Id,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    EbillsProductId = request.ebillsBillerProductDto.EbillsProductId,

                    CreatedDate = DateTime.UtcNow
                };

                var savedEbillsProduct = await _billerEbillsProductRepository.Add(ebillProduct);

                await _billerEbillsProductRepository.CommitAsync();

                return ResponseGenerator.Response("Created Sccessfully", _responseCode.Created, true, new { EbillsBillerProductId = savedEbillsProduct.ReferenceKey });
            }
        }
    }
}
