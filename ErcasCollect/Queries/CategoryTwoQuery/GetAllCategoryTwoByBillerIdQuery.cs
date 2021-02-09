using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.CategoryTwoQuery
{
    public class GetAllCategoryTwoByBillerIdQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetAllCategoryTwoByBillerIdQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetAllCategoryTwoByBillerIdQueryHandler : IRequestHandler<GetAllCategoryTwoByBillerIdQuery, SuccessfulResponse>
        {

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetAllCategoryTwoByBillerIdQueryHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<CategoryOneService> categoryOneServiceRepository, 
                
                IGenericRepository<CategoryTwoService> categoryTwoServiceRepository, IGenericRepository<LevelDisplayName> levelDisplayNameRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetAllCategoryTwoByBillerIdQuery request, CancellationToken cancellationToken)
            {
                List<ReadAllCategoryTwoDto> categoryList = new List<ReadAllCategoryTwoDto>();

                var biller = await _billerRepository.FindSingleInclude(x => x.ReferenceKey == request._billerId, x => x.CategoryTwoService);

                if (biller == null)

                    ResponseGenerator.Response("Successful", _responseCode.NotFound, false);

                var mapCategoryTwo = biller.CategoryTwoService.Select(_mapper.Map<CategoryTwoService, ReadAllCategoryTwoDto>);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, mapCategoryTwo); 
            }
        }
    }
}
