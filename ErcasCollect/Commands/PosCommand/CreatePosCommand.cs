using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.PosCommand
{
    public class CreatePosCommand : IRequest<string>
    {
        public CreatePosDto createPosDto { get; set; }
        public class CreateBillerCommandHandler : IRequestHandler<CreatePosCommand, string>
        {
            private readonly IPosRepository posRepository;
            private readonly IMapper mapper;
            public CreateBillerCommandHandler(IPosRepository posRepository, IMapper mapper)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreatePosCommand request, CancellationToken cancellationToken)
            {

                Pos pos = mapper.Map<Pos>(request.createPosDto);
                await posRepository.Add(pos);
                await posRepository.CommitAsync();

                return pos.Id;
            }
        }
    }
}
