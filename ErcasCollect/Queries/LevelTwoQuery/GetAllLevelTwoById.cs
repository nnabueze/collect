using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Commands.Dto.LevelTwoDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using static ErcasCollect.Commands.Dto.LevelTwoDto.LevelTwoResponseDto;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllLevelTwoByBillerQuery : IRequest<SuccessfulResponse>
    {

        public string _levelOneId { get; set; }

        public string _billerId { get; set; }

        public GetAllLevelTwoByBillerQuery(string levelOneId, string billerId)
        {
            _levelOneId = levelOneId;

            _billerId = billerId;
        }

        public class GetAllLevelTwoByBillerHandler : IRequestHandler<GetAllLevelTwoByBillerQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _leveloneRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            public GetAllLevelTwoByBillerHandler(IGenericRepository<LevelOne> leveloneRepository, IMapper mapper,

                IOptions<ResponseCode> responseCode, IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<Biller> billerRepository, 
                
                IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _leveloneRepository = leveloneRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _levelTwoRepository = levelTwoRepository;

                _billerRepository = billerRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllLevelTwoByBillerQuery request, CancellationToken cancellationToken)
            {

                var verifyRequest = VerifyRequest(request);

                if (verifyRequest != null)
                {
                    return verifyRequest;
                }


                var levelTwoResponse = GetResponse(request);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, levelTwoResponse);
            }

            private LevelTwoResponseDto GetResponse(GetAllLevelTwoByBillerQuery request)
            {
                var levelOne = GetLevelOne(request);

                var biller = GetBiller(request);

                var levelTwoDisplayName = GetLevelTwoDisplayName(biller.Id);

                var levelTwo = _levelTwoRepository.Find(x => x.LevelOneId == levelOne.Id).Select(_mapper.Map<LevelTwo, LevelTwoItem>);

                var response = new LevelTwoResponseDto()
                {
                    DisplayName = levelTwoDisplayName,

                    LevelTwoItems = levelTwo
                };

                return response;
            }

            private string GetLevelTwoDisplayName(int billerId)
            {
                return _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId).LevelTwoDisplayName;
            }

            private SuccessfulResponse VerifyRequest(GetAllLevelTwoByBillerQuery request)
            {
                LevelOne levelOne = GetLevelOne(request);

                if (levelOne == null)
                {
                    return ResponseGenerator.Response("Invalid level One Id", _responseCode.NotFound, false);
                }

                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                return null;
            }

            private Biller GetBiller(GetAllLevelTwoByBillerQuery request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);
            }

            private LevelOne GetLevelOne(GetAllLevelTwoByBillerQuery request)
            {
                return _leveloneRepository.FindFirst(x => x.ReferenceKey == request._levelOneId);
            }
        }
    }
}

