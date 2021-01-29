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

namespace ErcasCollect.Commands.CategoryTwoCommand
{
    public class UpdateCategoryTwoCommand : IRequest<SuccessfulResponse>
    {
        public UpdateCategoryTwoDto updateCategoryTwoDto { get; set; }
        public class UpdateCategoryTwoCommandHandler : IRequestHandler<UpdateCategoryTwoCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public UpdateCategoryTwoCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository,                 
                
                IGenericRepository<CategoryOneService> categoryOneServiceRepository, IGenericRepository<CategoryTwoService> categoryTwoServiceRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _categoryOneServiceRepository = categoryOneServiceRepository;

                _categoryTwoServiceRepository = categoryTwoServiceRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(UpdateCategoryTwoCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                
                var biller = GetBiller(request);
                
                var levelOne = GetLevelOne(request, biller.Id);
                
                var categoryOne = GetCategoryOne(request, biller.Id);
                
                var verify = VerifyBiller(biller, levelOne, categoryOne);

                if (verify != null)
                {
                    return verify;
                }
                
                await UpdateCategoryTwo(request, biller.Id, levelOne.Id, categoryOne.Id);
                
                return ResponseGenerator.Response("Successful", _responseCode.OK, true);
            }

            private async Task UpdateCategoryTwo(UpdateCategoryTwoCommand request, int billerId, int levelOneId, int categoryOneId)
            {
                var categoryTwo = _categoryTwoServiceRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryTwoDto.CategoryTwoId && x.BillerId == billerId);

                categoryTwo.Amount = Convert.ToDecimal(request.updateCategoryTwoDto.Amount);

                categoryTwo.Name = request.updateCategoryTwoDto.Name;

                categoryTwo.IsAmountFixed = Convert.ToBoolean(request.updateCategoryTwoDto.IsAmountFixed);

                categoryTwo.CategoryOneServiceId = categoryOneId;

                categoryTwo.LevelOneId = levelOneId;

                categoryTwo.ModifiedDate = DateTime.UtcNow;

                _categoryTwoServiceRepository.Update(categoryTwo);

                await _categoryTwoServiceRepository.CommitAsync();
                
            }

            private SuccessfulResponse VerifyBiller(Biller biller, LevelOne levelOne, CategoryOneService categoryOneService)
            {

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                if (levelOne == null)
                {
                    return ResponseGenerator.Response("Invalid level one id", _responseCode.NotFound, false);
                }

                if (categoryOneService == null)
                {
                    return ResponseGenerator.Response("Invalid category one id", _responseCode.NotFound, false);
                }

                return null;
            }

            private CategoryOneService GetCategoryOne(UpdateCategoryTwoCommand request, int billerId)
            {
                return _categoryOneServiceRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryTwoDto.CategoryOneId && x.BillerId == billerId);
            }
            private LevelOne GetLevelOne(UpdateCategoryTwoCommand request, int billerId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryTwoDto.LevelOneId && x.BillerId == billerId);
            }

            private Biller GetBiller(UpdateCategoryTwoCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.updateCategoryTwoDto.BillerId && x.IsDeleted == false);
            }
        
        }
    }
}
