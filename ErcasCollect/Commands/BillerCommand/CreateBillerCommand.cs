using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ErcasCollect.Commands.BillerCommand
{
    public class CreateBillerCommand:IRequest<SuccessfulResponse>
    {
        public CreateBillerDto createBillerDto { get; set; }

        public class CreateBillerCommandHandler : IRequestHandler<CreateBillerCommand, SuccessfulResponse>
        {
            private readonly IBillerRepository _billerRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IWebCallService _webCallService;

            private readonly WebEndpoint _webEndpoint;

            public CreateBillerCommandHandler(IBillerRepository billerRepository, IMapper mapper, IOptions<ResponseCode> responseCode, 
                
                IWebCallService webCallService, IOptions<WebEndpoint> webEndpoint)
            {
                _billerRepository = billerRepository ?? throw new ArgumentNullException(nameof(billerRepository));

                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _responseCode = responseCode.Value;

                _webCallService = webCallService;

                _webEndpoint = webEndpoint.Value;
            }

            public async Task<SuccessfulResponse> Handle(CreateBillerCommand request, CancellationToken cancellationToken)
            {

                Biller biller = _mapper.Map<Biller>(request.createBillerDto);

                biller.ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15);

                //call api gateway to onboard biller



                await OnboardBillerOnGateway(biller);

                //is onboarding biller on api gateway failed

                //save biller
                var addedBiller = await _billerRepository.Add(biller);

                await _billerRepository.CommitAsync();

                //send notification to biller

                //return response
                return new SuccessfulResponse()
                {
                    Message = "Biller Created",

                    StatusCode = _responseCode.Created,

                    IsSuccess = true,

                    Data = new
                    {
                        BillerId = addedBiller.ReferenceKey
                    }
                };
            }

            private async Task OnboardBillerOnGateway(Biller biller)
            {
                var gatewayData = new
                {
                    billerData = new
                    {
                        companyName = biller.Name,

                        companyEmail = biller.Email,

                        companyPhone = biller.PhoneNumber,

                        companyInformation = biller.Description,

                        address = biller.Address,

                        services = [new
                        {

                            id = 2
                        }]
                    }
                };

                var gatewayDataJson = JsonConvert.SerializeObject(gatewayData);

                var gatewayResponse = await _webCallService.PostDataCall(_webEndpoint.GatewayOnBoard, gatewayDataJson);
            }
        }
    }
}



