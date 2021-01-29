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
    public class UpdateCategoryOneCommand : IRequest<SuccessfulResponse>
    {
        public UpdateCategoryOneDto updateCategoryOneDto { get; set; }
        public class UpdateCategoryOneCommandHandler : IRequestHandler<UpdateCategoryOneCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public UpdateCategoryOneCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository, 
                
                IGenericRepository<CategoryOneService> categoryOneServiceRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(UpdateCategoryOneCommand request, CancellationToken cancellationToken)
            {
                var verify = VerifyBiller(request);

                if (verify != null)
                {
                    return verify;
                }
                var biller = GetBiller(request);

                var levelOne = GetLevelOne(request, biller.Id);

                await UpdateCategoryOne(request, biller.Id, levelOne.Id);

                return ResponseGenerator.Response("Updated Successfully", _responseCode.OK, true);

            }

            private async Task UpdateCategoryOne(UpdateCategoryOneCommand request, int billerId, int LevelOneId)
            {
                var categoryOne = _categoryOneServiceRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryOneDto.CategoryOneId && x.BillerId == billerId);

                categoryOne.Name = request.updateCategoryOneDto.Name;

                categoryOne.LevelOneId = LevelOneId;

                _categoryOneServiceRepository.Update(categoryOne);

                await _categoryOneServiceRepository.CommitAsync();
            }


            private SuccessfulResponse VerifyBiller(UpdateCategoryOneCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                LevelOne levelOne = GetLevelOne(request, biller.Id);

                if (levelOne == null)
                {
                    return ResponseGenerator.Response("Invalid level one id", _responseCode.NotFound, false);
                }

                return null;
            }

            private LevelOne GetLevelOne(UpdateCategoryOneCommand request, int billerId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryOneDto.LevelOneId && x.BillerId == billerId);
            }

            private Biller GetBiller(UpdateCategoryOneCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryOneDto.BillerId && x.IsDeleted == false);
            }

        }
    }
}
