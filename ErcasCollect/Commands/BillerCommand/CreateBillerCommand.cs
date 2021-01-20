using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Commands.BillerCommand
{
    public class CreateBillerCommand:IRequest<SuccessfulResponse>
    {
        public CreateBillerDto createBillerDto { get; set; }

        public class CreateBillerCommandHandler : IRequestHandler<CreateBillerCommand, SuccessfulResponse>
        {
            private readonly IBillerRepository _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode responseCode;

            public CreateBillerCommandHandler(IBillerRepository billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                this.responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateBillerCommand request, CancellationToken cancellationToken)
            {

                Biller biller  = _mapper.Map<Biller>(request.createBillerDto);

                var addedBiller = await _billerRepository.Add(biller);

                 await _billerRepository.CommitAsync();

                return new SuccessfulResponse()
                {
                    Message ="Biller Created",

                    StatusCode = responseCode.Created,

                    IsSuccess = true,

                    Data = new
                    {
                        BillerId = addedBiller.Id
                    }
                };
            }
        }
        }
}



