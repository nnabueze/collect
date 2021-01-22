using ErcasCollect.Commands.Dto.SettlementDto;
using ErcasCollect.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.SettlementCommand
{
    public class FlexSettlementCommand : IRequest<SuccessfulResponse>
    {
        public FlexSettlementDto FlexSettlementDto { get; set; }

        public class FlexSettlementCommandHandler : IRequestHandler<FlexSettlementCommand, SuccessfulResponse>
        {      

            public Task<SuccessfulResponse> Handle(FlexSettlementCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
