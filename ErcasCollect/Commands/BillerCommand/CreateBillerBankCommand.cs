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
    public class CreateBillerBankCommand : IRequest<int>
    {
        public AddBankDto createBillerBankDto { get; set; }
        public class CreateBillerBankCommandHandler : IRequestHandler<CreateBillerBankCommand, int>
        {
            private readonly IBillerBankRepository billerRepository;
            private readonly IMapper mapper;
            public CreateBillerBankCommandHandler(IBillerBankRepository billerRepository, IMapper mapper)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<int> Handle(CreateBillerBankCommand request, CancellationToken cancellationToken)
            { 

                BillerBankDetail billerbank = mapper.Map<BillerBankDetail>(request.createBillerBankDto);
                await billerRepository.Insert(billerbank);

                return billerbank.Id;
            }

        
        }
    }
}