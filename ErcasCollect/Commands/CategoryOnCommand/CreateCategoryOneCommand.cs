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

namespace ErcasCollect.Commands.CategoryOnCommand
{
    public class CreateCategoryOneCommand : IRequest<SuccessfulResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }

        public class CreateCategoryOneCommandHandler : IRequestHandler<CreateCategoryOneCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public CreateCategoryOneCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository, 
                
                IGenericRepository<CategoryOneService> categoryOneServiceRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateCategoryOneCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                //verify request
                var verify = VerifyBiller(request);

                if (verify != null)
                {
                    return verify;
                }

                var biller = GetBiller(request);

                var levelOne = GetLevelOne(request);

                var response = await SaveCategoryOne(request, biller.Id, levelOne.Id);

                return ResponseGenerator.Response("Created", _responseCode.Created, true, new { categoryOneId = response });
            }

            private async Task<string> SaveCategoryOne(CreateCategoryOneCommand request, int billerId, int leveloneId)
            {
                var categoryOne = new CategoryOneService()
                {
                    BillerId = billerId,

                    LevelOneId = leveloneId,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    Name = request.CreateCategoryDto.Name
                };

                var savedCategoryOne = await _categoryOneServiceRepository.Add(categoryOne);

                await _categoryOneServiceRepository.CommitAsync();

                return savedCategoryOne.ReferenceKey;
            }

            private SuccessfulResponse VerifyBiller(CreateCategoryOneCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                LevelOne levelOne = GetLevelOne(request);

                if (levelOne == null)
                {
                    return ResponseGenerator.Response("Invalid level one id", _responseCode.NotFound, false);
                }

                return null;
            }

            private LevelOne GetLevelOne(CreateCategoryOneCommand request)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.CreateCategoryDto.LevelOneId);
            }

            private Biller GetBiller(CreateCategoryOneCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.CreateCategoryDto.BillerId && x.IsDeleted == false);
            }
        }
    }
}
