using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
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

namespace ErcasCollect.Commands.PosCommand
{
    public class AddPosCommand : IRequest<SuccessfulResponse>
    {
        public AddPosDto AddPosDto { get; set; }

        public class AddPosCommandHandler : IRequestHandler<AddPosCommand, SuccessfulResponse>
        {
            private readonly IPosRepository _posRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly NameConstant _nameConstant;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            public AddPosCommandHandler(IPosRepository posRepository, IMapper mapper, IOptions<ResponseCode> responseCode, IOptions<NameConstant> nameConstant, 
                
                IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<Biller> billerRepository)
            {
                _posRepository = posRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _nameConstant = nameConstant.Value;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(AddPosCommand request, CancellationToken cancellationToken)
            {
                var pos = new Pos()
                {
                    CreatedDate = DateTime.UtcNow,

                    LevelTwoId = GetLevelTwoId(request.AddPosDto.LevelTwoId),

                    LevelOneId = GetLevelOneId(request.AddPosDto.LevelTwoId),

                    ActivationPin = Helpers.IdGenerator.IdGenerator.RandomInt(5),

                    BillerId = GetBiller(request.AddPosDto.BillerId),

                    PosImei = request.AddPosDto.PosImei,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15)
                    
                };

                var savedPos = await _posRepository.Add(pos);

                await _posRepository.CommitAsync();

                return ResponseGenerator.Response(_nameConstant.Created, _responseCode.Created, true, new { savedPos.ActivationPin });
            }


            private int GetLevelOneId(string levelOneId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == levelOneId).Id;
            }

            private int GetLevelTwoId(string levelTwoId)
            {
                return _levelTwoRepository.FindFirst(x => x.ReferenceKey == levelTwoId).Id;
            }

            private int GetBiller(string billerId)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == billerId).Id;
            }
        }
    }
}
