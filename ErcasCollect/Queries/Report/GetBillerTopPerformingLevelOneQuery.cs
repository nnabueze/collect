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
    public class GetBillerTopPerformingLevelOneQuery : IRequest<SuccessfulResponse>
    {
        private string _billerId;

        public GetBillerTopPerformingLevelOneQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetBillerTopPerformingLevelOneQueryHandler : IRequestHandler<GetBillerTopPerformingLevelOneQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<BillerTopPerformingLevelOne> _billerTopPerformingLevelOneRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            public GetBillerTopPerformingLevelOneQueryHandler(IGenericRepository<Biller> billerRepository, IGenericRepository<BillerTopPerformingLevelOne> billerTopPerformingLevelOneRepository,

                IMapper mapper, IOptions<ResponseCode> responseCode, IGenericRepository<LevelOne> levelOneRepository)
            {
                _billerRepository = billerRepository;

                _billerTopPerformingLevelOneRepository = billerTopPerformingLevelOneRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _levelOneRepository = levelOneRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetBillerTopPerformingLevelOneQuery request, CancellationToken cancellationToken)
            {
                List<BillerTopPerformingLevelOneDto> topPerformingList = new List<BillerTopPerformingLevelOneDto>();
                
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);

                if (biller == null)

                    return ResponseGenerator.Response("Successful", _responseCode.NotFound, false);

                var topLevelOnes = GetTopPerformingLevelOne(biller.Id);

                if (topLevelOnes == null)

                    return ResponseGenerator.Response("Not level One in the system", _responseCode.NotAccepted, false);

                foreach (var item in topLevelOnes)
                {
                    var levelOne = _levelOneRepository.FindFirst(x => x.Id == item.LevelOneId);

                    var topPerformingDto = new BillerTopPerformingLevelOneDto()
                    {
                        Name = levelOne.Name,

                        Amount = item.TotalAmount.ToString()
                    };

                    topPerformingList.Add(topPerformingDto);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, topPerformingList);
            }

            private List<BillerTopPerformingLevelOne> GetTopPerformingLevelOne(int billerId)
            {
                return  _billerTopPerformingLevelOneRepository.Find(x => x.BillerId == billerId).ToList();
            }
        }
    }
}
