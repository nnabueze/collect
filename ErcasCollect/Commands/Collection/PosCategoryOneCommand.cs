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
    public class PosCategoryOneCommand : IRequest<SuccessfulResponse>
    {
        public PosCategoryOneDto PosCategoryOneDto { get; set; }

        public class PosCategoryOneCommandHandler : IRequestHandler<PosCategoryOneCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneRepository;

            private readonly IMapper _mapper;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            public PosCategoryOneCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<LevelOne> levelOneRepository,

                IGenericRepository<Biller> billerRepository, IGenericRepository<Pos> posRespository,

                IGenericRepository<User> userRepository, IMapper mapper, IGenericRepository<CategoryOneService> categoryOneRepository, 
                
                IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _responseCode = responseCode.Value;

                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;

                _categoryOneRepository = categoryOneRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(PosCategoryOneCommand request, CancellationToken cancellationToken)
            {
                //auto mapper
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.PosCategoryOneDto.BillerId);

                if (biller == null || biller.IsDeleted)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                var pos = _posRespository.FindFirst(x => x.ReferenceKey == request.PosCategoryOneDto.PosId);

                if (pos == null || !pos.IsActive)
                {
                    return ResponseGenerator.Response("Invalid pos Id or pos not active", _responseCode.NotFound, false);
                }

                var user = _userRepository.FindFirst(x => x.ReferenceKey == request.PosCategoryOneDto.UserId);

                if (user == null || !user.IsActive)
                {
                    return ResponseGenerator.Response("Invalid user Id or use not active", _responseCode.NotFound, false);
                }

                var response = PosResponse(request, biller);

                return ResponseGenerator.Response("Succesful", _responseCode.OK, true, response);
            }

            private PosCategoryOneRespnse PosResponse(PosCategoryOneCommand request, Biller biller)
            {
                var levelOneId = _levelOneRepository.FindFirst(x => x.ReferenceKey == request.PosCategoryOneDto.LevelOneId).Id;

                var listCategoryOne = _categoryOneRepository.Find(x => x.LevelOneId == levelOneId).ToList().Select(_mapper.Map<CategoryOneService, PosCategoryOneRespnse.CategoryOneParameter>);

                var categoryOneDisplayName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == biller.Id).CategoryOneDisplayName;

                var response = new PosCategoryOneRespnse()
                {
                    LevelOneId = request.PosCategoryOneDto.LevelOneId,

                    CategoryOneDisplayName = categoryOneDisplayName,

                    CategoryOne = listCategoryOne
                };
                return response;
            }
        }
    }
}
