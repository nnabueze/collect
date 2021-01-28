using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.BranchCommand
{
    public class CreateLevelOneCommand : IRequest<SuccessfulResponse>
    {
        public CreateLevelOneDto createLevelOneDto { get; set; }
        public class CreateLevelOneCommandHandler : IRequestHandler<CreateLevelOneCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public CreateLevelOneCommandHandler(IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository, 
                
                IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateLevelOneCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var checkBiller = VerifyBiller(request);

                if (checkBiller != null)
                {
                    return checkBiller;
                }

                
                var savedLevelOne = await SaveLevelOne(request);

                return ResponseGenerator.Response("Created", _responseCode.Created, true, new { LevelOneId = savedLevelOne });
            }

            private SuccessfulResponse VerifyBiller(CreateLevelOneCommand request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller id", _responseCode.NotFound, false);
                }

                return null;
            }

            private Biller GetBiller(CreateLevelOneCommand request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request.createLevelOneDto.BillerId && x.IsDeleted == false);
            }

            private async Task<string> SaveLevelOne(CreateLevelOneCommand request)
            {
                var biller = GetBiller(request);

                var levelOne = new LevelOne()
                {
                    BillerId = biller.Id,

                    Description = request.createLevelOneDto.Description,

                    FundsweepPercentage = Convert.ToDecimal(request.createLevelOneDto.FundsweepPercentage),

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    Name = request.createLevelOneDto.Name
                };

                var savedLevelOne = await _levelOneRepository.Add(levelOne);

                await _levelOneRepository.CommitAsync();

                return savedLevelOne.ReferenceKey;
            }
        }
    }
}



