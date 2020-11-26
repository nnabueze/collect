using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Responses;
using MediatR;

namespace ErcasCollect.Commands.PosCommand
{
    public class ActivatePosCommand : IRequest<ActivateResponse>
    {
        public ActivatePosDto createPosDto { get; set; }
        public class CreateBillerCommandHandler : IRequestHandler<ActivatePosCommand, ActivateResponse>
        {
            private readonly IPosRepository posRepository;
            private readonly IMapper mapper;
            public CreateBillerCommandHandler(IPosRepository posRepository, IMapper mapper)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<ActivateResponse> Handle(ActivatePosCommand request, CancellationToken cancellationToken)
            {

                var checkposcommand = await posRepository.GetSingle(x => x.Id == request.createPosDto.PosId);
                if (request.createPosDto.isActivation == true)
                {
                    if (checkposcommand.Activationpin == request.createPosDto.PIN)
                    {
                        checkposcommand.StatusId = "400";
                        checkposcommand.UserId = request.createPosDto.UserId;
                        posRepository.Update(checkposcommand);
                        await posRepository.CommitAsync();
                        return new ActivateResponse { Message = "POS Activated", StatusCode = "400" };
                    }
                    else
                    {
                        return new ActivateResponse { Message = "Invalid PIN", StatusCode = "001" };
                    }
                }
                else
                {
                    checkposcommand.StatusId = "415";
                    posRepository.Update(checkposcommand);
                    await posRepository.CommitAsync();
                    return new ActivateResponse { Message = "POS Deactivated", StatusCode = "415" };
                }

            }
        }
    }
}
