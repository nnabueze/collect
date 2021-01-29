using AutoMapper;
using ErcasCollect.Commands.Dto.CategoryTwoDto;
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
using static ErcasCollect.Commands.Dto.CategoryTwoDto.CategoryTwoResponseDto;

namespace ErcasCollect.Queries.CategoryTwoQuery
{
    public class GetAllCategoryTwoByCategoryQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        private string _categoryOneId;

        public GetAllCategoryTwoByCategoryQuery(string billerId, string categoryOneId)
        {
            _billerId = billerId;

            _categoryOneId = categoryOneId;
        }

        public class GetAllCategoryTwoByCategoryQueryHandler : IRequestHandler<GetAllCategoryTwoByCategoryQuery, SuccessfulResponse>
        {

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetAllCategoryTwoByCategoryQueryHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<CategoryOneService> categoryOneServiceRepository,

                IGenericRepository<CategoryTwoService> categoryTwoServiceRepository, IMapper mapper, IOptions<ResponseCode> responseCode, IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllCategoryTwoByCategoryQuery request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = GetBiller(request);

                var categoryOne = GetCategoryOne(request, biller.Id);
               
                var verify = VerifyBiller(biller, categoryOne);
                
                var response = GetResponse(request, biller.Id, categoryOne.Id);

                return ResponseGenerator.Response("Sucessful", _responseCode.OK, true, response);
            }

            private CategoryTwoResponseDto GetResponse(GetAllCategoryTwoByCategoryQuery request, int billerId, int categoryOneId)
            {
                var displayName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId).CategoryTwoDisplayName;

                var categoryTwo = _categoryTwoServiceRepository.Find(x => x.CategoryOneServiceId == categoryOneId && x.BillerId == billerId)

                    .Select(_mapper.Map<CategoryTwoService, CategoryTwoItem>);

                var response = new CategoryTwoResponseDto()
                {
                    DisplayName = displayName,

                    CategoryTwoItems = categoryTwo
                };

                return response;
            }

            private SuccessfulResponse VerifyBiller(Biller biller, CategoryOneService categoryOneService)
            {

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                if (categoryOneService == null)
                {
                    return ResponseGenerator.Response("Invalid category one id", _responseCode.NotFound, false);
                }

                return null;
            }

            private CategoryOneService GetCategoryOne(GetAllCategoryTwoByCategoryQuery request, int billerId)
            {
                return _categoryOneServiceRepository.FindFirst(x => x.ReferenceKey == request._categoryOneId && x.BillerId == billerId);
            }

            private Biller GetBiller(GetAllCategoryTwoByCategoryQuery request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId && x.IsDeleted == false);
            }
        }
    }
}
