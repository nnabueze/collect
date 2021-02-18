using AutoMapper;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.SqlViewModels;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Queries.Report
{
    public class GetBillerTopPerformingAgentQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetBillerTopPerformingAgentQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetBillerTopPerformingAgentQueryHandler : IRequestHandler<GetBillerTopPerformingAgentQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<BillerAgentCashAtHand> _BillerAgentCashAtHandRepository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetBillerTopPerformingAgentQueryHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<BillerAgentCashAtHand> billerAgentCashAtHandRepository, 
                
                IGenericRepository<User> userRepository, IMapper mapper, IOptions<ResponseCode> responseCode)
            {
                _billerRepository = billerRepository;

                _BillerAgentCashAtHandRepository = billerAgentCashAtHandRepository;

                _userRepository = userRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerTopPerformingAgentQuery request, CancellationToken cancellationToken)
            {
                List<BillerTopPerformingAgentDto> topAgentList = new List<BillerTopPerformingAgentDto>();

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);

                if (biller == null)

                    return ResponseGenerator.Response("Succesful", _responseCode.NotFound, false);

                var topAgent = GetTopPerformingAgent(biller.Id);

                if (topAgent == null)

                    return ResponseGenerator.Response("No agent with cash at hand", _responseCode.OK, true);

                foreach (var item in topAgent)
                {
                    if (item.TotalCashAtHand != Convert.ToDecimal("0.00"))
                    {
                        var user = _userRepository.FindFirst(x => x.Id == item.UserId);

                        var agent = new BillerTopPerformingAgentDto()
                        {
                            AgentName = user.Name,

                            AgentPhone = user.PhoneNumber,

                            Amount = item.TotalCashAtHand.ToString()
                        };

                        topAgentList.Add(agent);
                    }
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, topAgentList);
            }

            private List<BillerAgentCashAtHand> GetTopPerformingAgent(int billerId)
            {
                return _BillerAgentCashAtHandRepository.Find(x => x.BillerId == billerId).ToList();
            }
        }
    }
}
