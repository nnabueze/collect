using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
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

namespace ErcasCollect.Commands.LevelOneCommand
{
    public class UpdateLevelOneCommand : IRequest<SuccessfulResponse>
    {
        public UpdateLevelOneDto updateLevelOneDto { get; set; }

        public class UpdateLevelOneCommandHandler : IRequestHandler<UpdateLevelOneCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public UpdateLevelOneCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(UpdateLevelOneCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var checkBiller = VerifyBiller(request);

                if (checkBiller != null)
                {
                    return checkBiller;
                }

                
                await UpdateLevelOne(request);

                return ResponseGenerator.Response("Updated successfully", _responseCode.OK, true);
            }

            private SuccessfulResponse VerifyBiller(UpdateLevelOneCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                return null;
            }

            private Biller GetBiller(UpdateLevelOneCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.updateLevelOneDto.BillerId && x.IsDeleted == false);
            }

            private async Task UpdateLevelOne(UpdateLevelOneCommand request)
            {

                var levelOne =_levelOneRepository.FindFirst(x => x.ReferenceKey == request.updateLevelOneDto.LevelOneId);

                levelOne.Description = request.updateLevelOneDto.Description;

                levelOne.FundsweepPercentage = Convert.ToDecimal(request.updateLevelOneDto.FundsweepPercentage);

                levelOne.Name = request.updateLevelOneDto.Name;

                _levelOneRepository.Update(levelOne);

                await _levelOneRepository.CommitAsync();
            }
        }
    }
}
