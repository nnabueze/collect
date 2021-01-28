using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelTwoDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.LevelTwoCommand
{
    public class CreateLevelTwoCommand : IRequest<SuccessfulResponse>
    {
        public CreateLevelTwoDto createLeveltwoDto { get; set; }

        public class CreateLevelTwoCommandHandler : IRequestHandler<CreateLevelTwoCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public CreateLevelTwoCommandHandler(IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<Biller> billerRepository,

                IMapper mapper, IOptions<ResponseCode> responseCode, IGenericRepository<LevelOne> levelOneRepository)
            {
                _levelTwoRepository = levelTwoRepository;

                _billerRepository = billerRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _levelOneRepository = levelOneRepository;
            }

            public async Task<SuccessfulResponse> Handle(CreateLevelTwoCommand request, CancellationToken cancellationToken)
            {

                var checkBiller = VerifyBiller(request);

                if (checkBiller != null)
                {
                    return checkBiller;
                }


                var savedLevelTwo = await SaveLevelTwo(request);

                return ResponseGenerator.Response("Created", _responseCode.Created, true, new { LevelOneId = savedLevelTwo });
            }

            private SuccessfulResponse VerifyBiller(CreateLevelTwoCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                return null;
            }

            private Biller GetBiller(CreateLevelTwoCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.createLeveltwoDto.BillerId && x.IsDeleted == false);
            }

            private LevelOne GetLevel(CreateLevelTwoCommand request)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.createLeveltwoDto.LevelOneId);
            }

            private async Task<string> SaveLevelTwo(CreateLevelTwoCommand request)
            {
                var biller = GetBiller(request);

                var levelOne = GetLevel(request);

                var levelTwo = new LevelTwo()
                {
                    BillerId = biller.Id,

                    LevelOneId = levelOne.Id,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    Name = request.createLeveltwoDto.Name
                };

                var savedLevelTwo = await _levelTwoRepository.Add(levelTwo);

                await _levelTwoRepository.CommitAsync();

                return savedLevelTwo.ReferenceKey;
            }
        }
    }
}
