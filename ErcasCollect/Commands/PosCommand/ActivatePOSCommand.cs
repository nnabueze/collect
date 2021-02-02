using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.PosCommand
{
    public class ActivatePosCommand : IRequest<SuccessfulResponse>
    {
        public ActivatePosDto createPosDto { get; set; }
        public class CreateBillerCommandHandler : IRequestHandler<ActivatePosCommand, SuccessfulResponse>
        {
            private readonly IPosRepository _posRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            public CreateBillerCommandHandler(IPosRepository posRepository, IMapper mapper, IOptions<ResponseCode> responseCode,

                IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<Biller> billerRepository)
            {
                _posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));

                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _responseCode = responseCode.Value;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(ActivatePosCommand request, CancellationToken cancellationToken)
            {
                //auto mapped

                var checkPosPin = await _posRepository.GetSingle(x => x.ActivationPin == request.createPosDto.ActivationPin);

                if (checkPosPin == null)
                {
                    return ResponseGenerator.Response("Invalid activation pin", _responseCode.NotFound, false, request.createPosDto);
                }

                var posDetails = GetPosDetail(checkPosPin);

                if (checkPosPin.IsActive)
                {
                    return ResponseGenerator.Response("Account already activated", _responseCode.AccountActivated, true, posDetails);
                }

                checkPosPin.IsActive = true;

                checkPosPin.ModifiedDate = DateTime.UtcNow;

                 _posRepository.Update(checkPosPin);

                await _posRepository.CommitAsync();

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, posDetails);
            }

            private PosDetailsDto GetPosDetail(Pos pos)
            {
                var billerId = _billerRepository.FindFirst(x => x.Id == pos.BillerId).ReferenceKey;

                var leveOneId = _levelOneRepository.FindFirst(x => x.BillerId == pos.BillerId).ReferenceKey;

                var leveTwoId = _levelTwoRepository.FindFirst(x => x.BillerId == pos.BillerId).ReferenceKey;

                var posDetail = new PosDetailsDto()
                {
                    BillerId = billerId,

                    LevelOneId = leveOneId,

                    LevelTwoId = leveTwoId,

                    PosId = pos.ReferenceKey
                };

                return posDetail;
            }
        }
    }
}
