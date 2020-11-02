using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllPaymentChannelQuery : IRequest<IEnumerable<ReadPaymentChannelDto>>
    {


        public class GetAllPaymentChannelHandler : IRequestHandler<GetAllPaymentChannelQuery, IEnumerable<ReadPaymentChannelDto>>
        {
            private readonly IGenericRepository<PaymentChannel> paymentchanelRepository;
            private readonly IMapper mapper;

            public GetAllPaymentChannelHandler(IGenericRepository<PaymentChannel> paymentchanelRepository, IMapper mapper)
            {
                this.paymentchanelRepository = paymentchanelRepository ?? throw new ArgumentNullException(nameof(paymentchanelRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            }

            public async Task<IEnumerable<ReadPaymentChannelDto>> Handle(GetAllPaymentChannelQuery query, CancellationToken cancellationToken)
            {

                var result = await paymentchanelRepository.GetAll();
                if (result != null)
                {
                    var biller = mapper.Map<IEnumerable<ReadPaymentChannelDto>>(result);
                    return biller;
                }
                else
                {
                    return null;
                }

            }


        }
    }
}

