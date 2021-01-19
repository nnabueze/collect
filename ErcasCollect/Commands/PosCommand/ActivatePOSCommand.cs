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
    public class ActivatePosCommand : IRequest<ActivateResponse>
    {
        public ActivatePosDto createPosDto { get; set; }
        public class CreateBillerCommandHandler : IRequestHandler<ActivatePosCommand, ActivateResponse>
        {
            private readonly IPosRepository posRepository;
            private readonly IMapper mapper;
            private readonly ResponseCode _response;
            public CreateBillerCommandHandler(IPosRepository posRepository, IMapper mapper, IOptions<ResponseCode> response)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _response = response.Value;
            }

            public async Task<ActivateResponse> Handle(ActivatePosCommand request, CancellationToken cancellationToken)
            {

                var checkposcommand = await posRepository.GetSingle(x => x.Id == request.createPosDto.PosId);
                if (request.createPosDto.isActivation == true)
                {
                    if (checkposcommand.Activationpin == request.createPosDto.PIN)
                    {
                        checkposcommand.StatusCode = _response.POSActivated;
                        checkposcommand.UserId = request.createPosDto.UserId;
                        posRepository.Update(checkposcommand);
                        await posRepository.CommitAsync();
                        return new ActivateResponse { Message = "POS Activated", StatusCode = _response.POSActivated };
                    }
                    else
                    {
                        return new ActivateResponse { Message = "Invalid PIN", StatusCode = _response.InvalidPIN };
                    }
                }
                else
                {
                    checkposcommand.StatusCode = _response.POSDeactivated;
                    posRepository.Update(checkposcommand);
                    await posRepository.CommitAsync();
                    return new ActivateResponse { Message = "POS Deactivated", StatusCode = _response.POSDeactivated };
                }

            }
        }
    }
}
