using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Helpers.NIbbs;
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
                

                if (biller.IsGatewayOnbaord)
                {
                    var service = await GatewayService();

                    if (service == null)
                    {
                        return ResponseGenerator.Response("No service name EbillsPay on gateway", _responseCode.NotAccepted, false);
                    }

                    var gatewayResponse = await OnboardBillerOnGateway(biller, service);

                    if (gatewayResponse == null)
                    {
                        return ResponseGenerator.Response("Unable to onboard biller on gateway", _responseCode.NotAccepted, false);
                    }

                    if ((! string.IsNullOrEmpty(request.createBillerDto.ValidationUrl)) 
                        
                        && (! string.IsNullOrEmpty(request.createBillerDto.NotificationUrl)) )
                    {
                        var gatewayCallbackResponse = await AddCallbackUrlOnGateway(request, gatewayResponse);

                        if (gatewayCallbackResponse == null)
                        {
                            return ResponseGenerator.Response("Unable to add callback urls", _responseCode.NotAccepted, false);
                        }
                    }

                    biller.GatewayUsername = gatewayResponse.data.username;

                    biller.GatewaySecretKey = gatewayResponse.data.secretKey;

                    biller.GatewayKeyVector = gatewayResponse.data.keyVector;                    

                    //await SendMail(biller, gatewayResponse);
                }

                var addedBiller = await _billerRepository.Add(biller);

                await _billerRepository.CommitAsync();                

                return ResponseGenerator.Response("Biller Created", _responseCode.Created, true, new { BillerId = addedBiller.ReferenceKey });
            }

            public async Task<Data> GatewayService()
            {
                var gatewayServiceString = await _webCallService.GetWebCall(_webEndpoint.GatewayServices);

                var gatewayService = JsonXmlObjectConverter.Deserialize<GatewayServiceResponse>(gatewayServiceString);

                var service = gatewayService.data.Find(x => x.serviceName == _webEndpoint.EbillsPay);

                return service;
            }

            private async Task<GatewayOnboardResponse> OnboardBillerOnGateway(Biller biller, Data service)
            {
                List<Services> listService = new List<Services>()
                {
                    new Services()
                    {
                        id = service.id
                    }
                };

                var gatewayData = new
                {
                    billerData = new BillerData()
                    {
                        companyName = biller.Name,

                        companyEmail = biller.Email,

                        companyPhone = biller.PhoneNumber,

                        companyInformation = biller.Description,

                        address = biller.Address,

                        services = listService

                    }
                };

                var gatewayDataJson = JsonConvert.SerializeObject(gatewayData);

                var gatewayResponseString = await _webCallService.PostDataCall(_webEndpoint.GatewayOnBoard, gatewayDataJson);

                var gatewayResponse = JsonXmlObjectConverter.Deserialize<GatewayOnboardResponse>(gatewayResponseString);

                return gatewayResponse;
            }

            private async Task<GatewayCallbackResponse> AddCallbackUrlOnGateway(CreateBillerCommand request, GatewayOnboardResponse urlCallback)
            {
                var gatewayData = new
                {
                    ebillsPayService = new CallbackUrl()
                    {
                        keyVector = urlCallback.data.keyVector,

                        secretKey = urlCallback.data.secretKey,

                        validationUrl = request.createBillerDto.ValidationUrl,

                        notificationUrl = request.createBillerDto.NotificationUrl
                    }
                };

                var gatewayDataJson = JsonConvert.SerializeObject(gatewayData);

                var gatewayResponseString = await _webCallService.PostDataCall(_webEndpoint.GatewayCallbackUrl, gatewayDataJson);

                var gatewayResponse = JsonXmlObjectConverter.Deserialize<GatewayCallbackResponse>(gatewayResponseString);

                return gatewayResponse;
            }

            private async Task SendMail(Biller biller, GatewayOnboardResponse response)
            {
                var msg = "Kindly find below api keys. \r\n Username: "+biller.GatewayUsername+"\r\n SecretKey: "
                    
                    +biller.GatewaySecretKey+"\r\n KeyVector: "+biller.GatewayKeyVector+"\n\n Thanks \n Ercas Team";

                var mailToSend = new
                {
                    to = biller.Email,

                    subject = "Api Keys",

                    message = msg
                };

                var mailToSendJson = JsonConvert.SerializeObject(mailToSend);

                await _webCallService.PostDataCall(_webEndpoint.Mail, mailToSendJson);

            }
        }
    }
}



