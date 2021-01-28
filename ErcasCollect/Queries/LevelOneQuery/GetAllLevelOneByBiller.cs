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

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllLevelOneByBillerQuery : IRequest<SuccessfulResponse>
    {

        public string billerId { get; set; }

        public class GetAllLevelOneByBillerHandler : IRequestHandler<GetAllLevelOneByBillerQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<LevelOne> _leveloneRepository;

            private readonly IMapper _mapper;

            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Biller> _billerRepository;

            public GetAllLevelOneByBillerHandler(IGenericRepository<LevelOne> leveloneRepository, IMapper mapper, 
                
                IOptions<ResponseCode> responseCode, IGenericRepository<Biller> billerRepository)
            {
                _leveloneRepository = leveloneRepository;

                _mapper = mapper;

                _responseCode = responseCode.Value;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllLevelOneByBillerQuery request, CancellationToken cancellationToken)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.billerId);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                var levelOne = _leveloneRepository.Find(x => x.BillerId == biller.Id).Select(_mapper.Map<LevelOne, LevelOneResponseDto>);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, levelOne);
            }

        }
    }
}

