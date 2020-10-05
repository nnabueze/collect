using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.BillerCommand
{
    public class CreateTinCommand : IRequest<int>
    {
        public AddTinDto createBillerTinDto { get; set; }
        public class CreateTinCommandHandler : IRequestHandler<CreateTinCommand, int>
        {
            private readonly IBillerTinRepository billerRepository;
            private readonly IMapper mapper;
            public CreateTinCommandHandler(IBillerTinRepository billerRepository, IMapper mapper)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<int> Handle(CreateTinCommand request, CancellationToken cancellationToken)
            {

                BillerTINDetail billertin = mapper.Map<BillerTINDetail>(request.createBillerTinDto);
                await billerRepository.Insert(billertin);

                return billertin.Id;
            }


        }
    }
}
