using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.SettlementDto;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.SettlementCommand
{
    public class CreateSettlementCommand : IRequest<string>
    {
        public CreateSettlementDto createSettlementDto { get; set; }
        public class CreateSettlementCommandHandler : IRequestHandler<CreateSettlementCommand, string>
        {
            private readonly ISettlementRepository settlementRepository;
            private readonly IMapper mapper;
            public CreateSettlementCommandHandler(ISettlementRepository settlementRepository, IMapper mapper)
            {
                this.settlementRepository = settlementRepository ?? throw new ArgumentNullException(nameof(settlementRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateSettlementCommand request, CancellationToken cancellationToken)
            {

                Settlement settlement = mapper.Map<Settlement>(request.createSettlementDto);
                await settlementRepository.Insert(settlement);

                return settlement.Id;
            }
        }
    }
}
