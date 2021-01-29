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
    public class CreateCategoryTwoCommand : IRequest<SuccessfulResponse>
    {
        public CreateCategoryTwoDto createCategoryTwoDto { get; set; }
        public class CreateCategoryTwoCommandHandler : IRequestHandler<CreateCategoryTwoCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<CategoryOneService> _categoryOneServiceRepository;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public CreateCategoryTwoCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository, 
                
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

            public async Task<SuccessfulResponse> Handle(CreateCategoryTwoCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = GetBiller(request);

                var levelOne = GetLevelOne(request, biller.Id);

                var categoryOne = GetCategoryOne(request, biller.Id);

                var verify = VerifyBiller(request, biller, levelOne, categoryOne);

                if (verify != null)
                {
                    return verify;
                }

                var savedCategoryTwo = await SaveCategoryTwo(request, biller.Id, levelOne.Id, categoryOne.Id);

                return ResponseGenerator.Response("Created", _responseCode.Created, true, new { categoryTwoId = savedCategoryTwo });
            }

            private async Task<string>  SaveCategoryTwo(CreateCategoryTwoCommand request, int billerId, int levelOneId, int categoryOneId)
            {
                var categoryTwo = new CategoryTwoService()
                {
                    Amount = Convert.ToDecimal(request.createCategoryTwoDto.Amount),

                    IsAmountFixed = Convert.ToBoolean(request.createCategoryTwoDto.IsAmountFixed),

                    CategoryOneServiceId = categoryOneId,

                    LevelOneId = levelOneId,

                    BillerId = billerId,

                    Name = request.createCategoryTwoDto.Name,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15)
                };

                var savedCategoryTwo = await _categoryTwoServiceRepository.Add(categoryTwo);

                await _categoryTwoServiceRepository.CommitAsync();

                return savedCategoryTwo.ReferenceKey;
            }

            private SuccessfulResponse VerifyBiller(CreateCategoryTwoCommand request, Biller biller, LevelOne levelOne, CategoryOneService categoryOneService)
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

            private CategoryOneService GetCategoryOne(CreateCategoryTwoCommand request, int billerId)
            {
                return _categoryOneServiceRepository.FindFirst(x => x.ReferenceKey == request.createCategoryTwoDto.CategoryOneId && x.BillerId == billerId);
            }
            private LevelOne GetLevelOne(CreateCategoryTwoCommand request, int billerId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.createCategoryTwoDto.LevelOneId && x.BillerId == billerId);
            }

            private Biller GetBiller(CreateCategoryTwoCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.createCategoryTwoDto.BillerId && x.IsDeleted == false);
            }
        }
    }
}
