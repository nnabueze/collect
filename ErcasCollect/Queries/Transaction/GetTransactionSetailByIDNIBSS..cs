using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using ErcasCollect.Responses;
using MediatR;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetTransactionDetailByIDNIBBSQuery : IRequest<ValidationResponse>
    {

        //public int id { get; set; }
        //public class GetTransactionDetailByIDNIBBSHandler : IRequestHandler<GetTransactionDetailByIDNIBBSQuery, ValidationResponse>
        //{
        //    private readonly IGenericRepository<Transaction> transactionbybatchidRepository;
        //    private readonly IMapper mapper;

        //    public GetTransactionDetailByIDNIBBSHandler(IGenericRepository<Transaction> transactionbybatchidRepository, IMapper mapper)
        //    {
        //        this.transactionbybatchidRepository = transactionbybatchidRepository ?? throw new ArgumentNullException(nameof(transactionbybatchidRepository));
        //        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        //    }

        //    public async Task<ValidationResponse> Handle(GetTransactionDetailByIDNIBBSQuery query, CancellationToken cancellationToken)
        //    {

        //        var result = await transactionbybatchidRepository.FindSingleInclude(x => x.Id == query.id, x => x.StatusCode, x => x.User, x => x.Biller, x => x.PaymentChannel, x => x.TransactionType);
        //        if (result != null)
        //        {
        //            //var transactionbybatchid = mapper.Map<ReadTransactionDto>(result);
        //            //return transactionbybatchid;
        //            //return new ValidationResponse { ResponseCode = 0, NextStep = 0, BillerID = result.BillerId };
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //        return null;

        //    }


        //}
    }
}

