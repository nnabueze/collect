using AutoMapper;
using ErcasCollect.Commands.Dto.LevelTwoDto;
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

namespace ErcasCollect.Commands.LevelTwoCommand
{
    public class UpdateLevelTwoCommand : IRequest<SuccessfulResponse>
    {
        public UpdateLevelTwoDto updateLevelTwoDto { get; set; }

        public class UpdateLevelTwoCommandHandler : IRequestHandler<UpdateLevelTwoCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public UpdateLevelTwoCommandHandler(IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<LevelOne> levelOneRepository, 
                
                IGenericRepository<Biller> billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelTwoRepository = levelTwoRepository;

                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(UpdateLevelTwoCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var checkBiller = VerifyBiller(request);

                if (checkBiller != null)
                {
                    return checkBiller;
                }


                await UpdateLevelTwo(request);

                return ResponseGenerator.Response("Updated successfully", _responseCode.OK, true);
            }

            private SuccessfulResponse VerifyBiller(UpdateLevelTwoCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                return null;
            }

            private Biller GetBiller(UpdateLevelTwoCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.updateLevelTwoDto.BillerId && x.IsDeleted == false);
            }

            private async Task UpdateLevelTwo(UpdateLevelTwoCommand request)
            {
                LevelOne levelOne = GetLevelOne(request);

                var levelTwo = _levelTwoRepository.FindFirst(x =>x.ReferenceKey == request.updateLevelTwoDto.LevelTwoId);

                levelTwo.Name = request.updateLevelTwoDto.Name;

                levelTwo.LevelOneId = levelOne.Id;

                _levelTwoRepository.Update(levelTwo);

                await _levelTwoRepository.CommitAsync();
            }

            private LevelOne GetLevelOne(UpdateLevelTwoCommand request)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == request.updateLevelTwoDto.LevelOneId);
            }
        }
    }
}
