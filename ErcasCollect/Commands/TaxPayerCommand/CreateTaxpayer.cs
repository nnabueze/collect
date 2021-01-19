using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.TaxpayerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

namespace ErcasCollect.Commands.TaxPayerCommand
{
    public class CreateTaxPayerCommand : IRequest<int>
    {
        public CreateTaxpayerDto createTaxpayerDto { get; set; }
        public class CreateTaxPayerCommandHandler : IRequestHandler<CreateTaxPayerCommand, int>
        {
            private readonly ITaxPayerRepository taxpayerRepository;
            private readonly IMapper mapper;
            public CreateTaxPayerCommandHandler(ITaxPayerRepository taxpayerRepository, IMapper mapper)
            {
                this.taxpayerRepository =taxpayerRepository ?? throw new ArgumentNullException(nameof(taxpayerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<int> Handle(CreateTaxPayerCommand request, CancellationToken cancellationToken)
            {

                TaxPayer user = mapper.Map<TaxPayer>(request.createTaxpayerDto);
                await taxpayerRepository.Add(user);
                await taxpayerRepository.CommitAsync();

                return user.Id;
            }
        }
    }
}
