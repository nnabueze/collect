using AutoMapper;
using ErcasCollect.Commands.Dto.CategoryOneDto;
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
using static ErcasCollect.Commands.Dto.CategoryOneDto.CategoryOneResponseDto;

namespace ErcasCollect.Queries.CategoryOneQuery
{
    public class GetAllCategoryOneByLevelQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        private string _levelOneId;

        public GetAllCategoryOneByLevelQuery(string billerId, string levelOneId)
        {
            _billerId = billerId;

            _levelOneId = levelOneId;
        }

        public class GetAllCategoryOneByLevelQueryHandler : IRequestHandler<GetAllCategoryOneByLevelQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetAllCategoryOneByLevelQueryHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository,

                IGenericRepository<CategoryOneService> categoryOneServiceRepository, IMapper mapper, IOptions<ResponseCode> responseCode, 
                
                IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllCategoryOneByLevelQuery request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = GetBiller(request);

                var levelOne = GetLevelOne(request, biller.Id);

                var verify = VerifyBiller(request, biller, levelOne);

                if (verify != null)
                {
                    return verify;
                }

                var response = GetResponse(request, biller.Id, levelOne.Id);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, response);
            }

            private CategoryOneResponseDto GetResponse(GetAllCategoryOneByLevelQuery request, int billerId, int levelOneId)
            {
                var categoryOne = _categoryOneServiceRepository.Find(x => x.BillerId == billerId && x.LevelOneId == levelOneId)

                    .Select(_mapper.Map<CategoryOneService, CategoryOneItem>);

                var displayName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId).CategoryOneDisplayName;

                var response = new CategoryOneResponseDto()
                {
                    DisplayName = displayName,

                    CategoryOneItems = categoryOne
                };

                return response;
            }

            private SuccessfulResponse VerifyBiller(GetAllCategoryOneByLevelQuery request, Biller biller, LevelOne levelOne)
            {

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }


                if (levelOne == null)
                {
                    return ResponseGenerator.Response("Invalid level one id", _responseCode.NotFound, false);
                }

                return null;
            }

            private LevelOne GetLevelOne(GetAllCategoryOneByLevelQuery request, int billerId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request._levelOneId && x.BillerId == billerId);
            }

            private Biller GetBiller(GetAllCategoryOneByLevelQuery request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId && x.IsDeleted == false);
            }
        }
    }
}
