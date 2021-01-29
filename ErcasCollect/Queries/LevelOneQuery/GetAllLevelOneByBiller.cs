using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using static ErcasCollect.Commands.Dto.LevelOneDto.LevelOneResponseDto;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllLevelOneByBillerQuery : IRequest<SuccessfulResponse>
    {

        public string _billerId { get; set; }

        public GetAllLevelOneByBillerQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetAllLevelOneByBillerHandler : IRequestHandler<GetAllLevelOneByBillerQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _leveloneRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            public GetAllLevelOneByBillerHandler(IGenericRepository<LevelOne> leveloneRepository, IMapper mapper,

                IOptions<ResponseCode> responseCode, IGenericRepository<Biller> billerRepository, IGenericRepository<LevelDisplayName> levelDisplayNameRepository)
            {
                _leveloneRepository = leveloneRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _billerRepository = billerRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllLevelOneByBillerQuery request, CancellationToken cancellationToken)
            {
                var verifyRequest = VerifyRequest(request);

                if (verifyRequest != null)
                {
                    return verifyRequest;
                }


                var levelOneResponse = GetLevelOneResponse(request);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, levelOneResponse);
            }

            private LevelOneResponseDto GetLevelOneResponse(GetAllLevelOneByBillerQuery request)
            {
                var biller = GetBiller(request);

                var levelOne = _leveloneRepository.Find(x => x.BillerId == biller.Id).Select(_mapper.Map<LevelOne, LevelOneItem>);

                var levelOneDisplayName = GetLevelOneDisplayName(biller.Id);

                var response = new LevelOneResponseDto()
                {
                    DisplayName = levelOneDisplayName,

                    LevelOneItems = levelOne
                };

                return response;
            }

            private SuccessfulResponse VerifyRequest(GetAllLevelOneByBillerQuery request)
            {
                Biller biller = GetBiller(request);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                return null;
            }

            private string GetLevelOneDisplayName(int billerId)
            {
                return _levelDisplayNameRepository.FindFirst(x => x.BillerId == billerId).LevelOneDisplayName;
            }

            private Biller GetBiller(GetAllLevelOneByBillerQuery request)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == request._billerId);
            }
        }
    }
}

