using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using static ErcasCollect.Commands.Dto.LevelOneDto.CloseBatchTransactionDto;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetTransactionByBatchIDQuery : IRequest<SuccessfulResponse>
    {

        private string _closeBatchTransactId;

        public GetTransactionByBatchIDQuery(string closeBatchTransactId)
        {
            _closeBatchTransactId = closeBatchTransactId;
        }

        public class GetTransactionByBatchIDQueryHandler : IRequestHandler<GetTransactionByBatchIDQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransaction;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<User> _UserRepository;

            private readonly ResponseCode _responseCode;

            private readonly NameConstant _nameConstant;

            public GetTransactionByBatchIDQueryHandler(IGenericRepository<CloseBatchTransaction> closeBatchTransaction, IOptions<ResponseCode> responseCode,

                IOptions<NameConstant> nameConstant, IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<LevelOne> levelOneRepository,

                IGenericRepository<LevelTwo> levelTwoRepository, IGenericRepository<User> userRepository, IGenericRepository<Biller> billerRepository)
            {
                _closeBatchTransaction = closeBatchTransaction;

                _responseCode = responseCode.Value;

                _nameConstant = nameConstant.Value;

                _levelDisplayNameRepository = levelDisplayNameRepository;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;

                _UserRepository = userRepository;

                _billerRepository = billerRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetTransactionByBatchIDQuery request, CancellationToken cancellationToken)
            {
                //auto mapper

                var checkCloseBatch = GetCloseBatchTransaction(request._closeBatchTransactId);

                if (checkCloseBatch == null)

                    return ResponseGenerator.Response(_nameConstant.InvalidTransactionId, _responseCode.NotFound, false);

                var levelDisplayName = GetDisplayName(checkCloseBatch);

                var closeBatch = new CloseBatchTransactionDto()
                {
                    BillerName = GetBillerName((int)checkCloseBatch.BillerId),

                    GeneratedDate = checkCloseBatch.CreatedDate.ToString(),

                    IsPaid = checkCloseBatch.IsPaid.ToString(),

                    TotalAmount = checkCloseBatch.TotalAmount.ToString(),

                    UserName = GetUserName((int)checkCloseBatch.UserId),

                    PaidDate = checkCloseBatch.ModifiedDate.ToString(),

                    LevelOne = GetLevelOne(levelDisplayName, (int)checkCloseBatch.LevelOneId),

                    LevelTwo = GetLevelTwo(levelDisplayName, (int)checkCloseBatch.LevelTwoId)
                    
                };

                return ResponseGenerator.Response(_nameConstant.Successful, _responseCode.OK, true, closeBatch);

            }

            private string GetUserName(int userId)
            {
                return _UserRepository.FindFirst(x => x.Id == userId).Name;
            }

            private LevelDisplayName GetDisplayName(CloseBatchTransaction checkCloseBatch)
            {
                return  _levelDisplayNameRepository.FindFirst(x => x.BillerId == checkCloseBatch.BillerId);
            }

            private LevelOneDetail GetLevelOne(LevelDisplayName levelDisplayName, int levelOneId)
            {
                var levelOneName = _levelOneRepository.FindFirst(x => x.Id == levelOneId).Name;

                var levelDetail = new LevelOneDetail()
                {
                    Name = levelOneName,

                    DisplayName = levelDisplayName.LevelOneDisplayName
                };

                return levelDetail;
            }

            private LevelTwoDetail GetLevelTwo(LevelDisplayName levelDisplayName, int levelTwoId)
            {
                var levelTwoName = _levelTwoRepository.FindFirst(x => x.Id == levelTwoId).Name;

                var levelDetail = new LevelTwoDetail()
                {
                    Name = levelTwoName,

                    DisplayName = levelDisplayName.LevelTwoDisplayName
                };

                return levelDetail;
            }

            private string GetBillerName(int billerId)
            {
                return _billerRepository.FindFirst(x => x.Id == billerId).Name;
            }


            private CloseBatchTransaction GetCloseBatchTransaction(string closeBatchTransactionId)
            {
                return _closeBatchTransaction.FindFirst(x => x.ReferenceKey == closeBatchTransactionId);
            }
        }
    }
}

