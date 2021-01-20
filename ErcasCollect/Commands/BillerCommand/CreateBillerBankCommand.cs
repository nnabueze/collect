using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.BillerCommand
{
    public class CreateBillerBankCommand : IRequest<SuccessfulResponse>
    {
        public AddBankDto createBillerBankDto { get; set; }
        public class CreateBillerBankCommandHandler : IRequestHandler<CreateBillerBankCommand, SuccessfulResponse>
        {
            private readonly IBillerBankRepository billerRepository;
            private readonly IMapper mapper;
            private readonly ResponseCode responseCode;
            public CreateBillerBankCommandHandler(IBillerBankRepository billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                this.responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateBillerBankCommand request, CancellationToken cancellationToken)
            { 

                BankDetail billerbank = mapper.Map<BankDetail>(request.createBillerBankDto);
                await billerRepository.Insert(billerbank);

                return new SuccessfulResponse { StatusCode=responseCode.Created, Message="Successfully Added"};
            }

        
        }
    }
}