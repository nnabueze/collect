using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
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

namespace ErcasCollect.Commands.Collection
{
    public class PosCategoryTwoCommand : IRequest<SuccessfulResponse>
    {
        public PosCategoryTwoDto posCategoryTwoDto { get; set; }
        public class PosCategoryTwoCommandHandler : IRequestHandler<PosCategoryTwoCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneRepository;

            private readonly IMapper _mapper;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            public PosCategoryTwoCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<CategoryTwoService> categoryTwoServiceRepository,

                IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository, IGenericRepository<User> userRepository,

                IGenericRepository<CategoryOneService> categoryOneRepository, IMapper mapper, IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _responseCode = responseCode.Value;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _categoryOneRepository = categoryOneRepository;

                _mapper = mapper;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(PosCategoryTwoCommand request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.posCategoryTwoDto.BillerId);

                if (biller == null || biller.IsDeleted)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                var pos = _posRespository.FindFirst(x => x.ReferenceKey == request.posCategoryTwoDto.PosId);

                if (pos == null || !pos.IsActive)
                {
                    return ResponseGenerator.Response("Invalid pos Id or pos not active", _responseCode.NotFound, false);
                }

                var user = _userRepository.FindFirst(x => x.ReferenceKey == request.posCategoryTwoDto.UserId);

                if (user == null || !user.IsActive)
                {
                    return ResponseGenerator.Response("Invalid user Id or use not active", _responseCode.NotFound, false);
                }

                var response = PosResponse(request, biller);

                return ResponseGenerator.Response("Succesful", _responseCode.OK, true, response);
            }

            private PosCategoryTwoRespnse PosResponse(PosCategoryTwoCommand request, Biller biller)
            {
                var categoryOneId = _categoryOneRepository.FindFirst(x => x.ReferenceKey == request.posCategoryTwoDto.CategoryOneId).Id;

                var listCategoryTwo = _categoryTwoServiceRepository.Find(x => x.CategoryOneServiceId == categoryOneId).ToList()
                    
                    .Select(_mapper.Map<CategoryTwoService, PosCategoryTwoRespnse.CategoryTwoParameter>);

                var categorytTwoDisplayName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == biller.Id).CategoryTwoDisplayName;

                var response = new PosCategoryTwoRespnse()
                {
                    CategoryOneId = request.posCategoryTwoDto.CategoryOneId,

                    CategoryTwoDisplayName = categorytTwoDisplayName,

                    CategoryTwo = listCategoryTwo
                };

                return response;
            }
        }
    }
}
