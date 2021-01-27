using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class PosLogoutCommand : IRequest<SuccessfulResponse>
    {
        public PosLogoutDto posLogoutDto { get; set; }

        public class PosLogoutCommandHandler : IRequestHandler<PosLogoutCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            public PosLogoutCommandHandler(IOptions<ResponseCode> responseCode, IGenericRepository<Biller> billerRepository, 
                
                IGenericRepository<Pos> posRespository, IGenericRepository<User> userRepository, IMapper mapper)
            {
                _responseCode = responseCode.Value;

                _billerRepository = billerRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;
            }

            public async Task<SuccessfulResponse> Handle(PosLogoutCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.posLogoutDto.BillerId);

                if (biller == null)
                {
                    return ResponseGenerator.Response("Invalid biller Id", _responseCode.NotFound, false);
                }

                var user = _userRepository.FindFirst(x => x.ReferenceKey == request.posLogoutDto.UserId);

                if (user == null)
                {
                    return ResponseGenerator.Response("Invalid user Id", _responseCode.NotFound, false);
                }

                var pos = _posRespository.FindFirst(x => x.ReferenceKey == request.posLogoutDto.PosId);

                if (pos == null)
                {
                    return ResponseGenerator.Response("Invalid pos Id", _responseCode.NotFound, false);
                }

                await UpdatePos(user, pos);

                return ResponseGenerator.Response("Successflly logout", _responseCode.OK, true);
            }

            private async Task UpdatePos(User user, Pos pos)
            {
                pos.IsLogin = false;

                pos.UserId = 0;

                pos.LastUserId = user.Id;

                _posRespository.Update(pos);

                await _posRespository.CommitAsync();
            }
        }
    }
}
