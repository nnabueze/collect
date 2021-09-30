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
    public class CreateTinCommand : IRequest<SuccessfulResponse>
    {
        public AddTinDto createBillerTinDto { get; set; }
        public class CreateTinCommandHandler : IRequestHandler<CreateTinCommand, SuccessfulResponse>
        {
            private readonly IBillerTinRepository billerRepository;
            private readonly IMapper mapper;
            private readonly ResponseCode _responseCode;
            public CreateTinCommandHandler(IBillerTinRepository billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                this.billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateTinCommand request, CancellationToken cancellationToken)
            {

                BillerTINDetail billertin = mapper.Map<BillerTINDetail>(request.createBillerTinDto);
                await billerRepository.Insert(billertin);

                return new SuccessfulResponse { Message="Biller TIN Created", StatusCode=_responseCode.Created};
            }


        }
    }
}
