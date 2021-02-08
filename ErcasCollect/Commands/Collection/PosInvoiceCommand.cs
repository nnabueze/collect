using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class PosInvoiceCommand : IRequest<SuccessfulResponse>
    {
        public PosInvoiceDto posInvoiceDto { get; set; }

        public class PosInvoiceCommandHandler : IRequestHandler<PosInvoiceCommand, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            private readonly IGenericRepository<Transaction> _transactionRepository;

            private readonly IGenericRepository<Batch> _BatchRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            private readonly IGenericRepository<CategoryTwoService> _categoryTwoServiceRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly IGenericRepository<CloseBatchTransaction> _closeBatchTransactionRepository;

            public Task<SuccessfulResponse> Handle(PosInvoiceCommand request, CancellationToken cancellationToken)
            {
                //Get and check level two

                //add batch tranasction

                //add trabsaction

                //add close batch

                //send email

                //retyrn response
                return null;
            }
        }
    }
}
