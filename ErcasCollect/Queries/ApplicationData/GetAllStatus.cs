using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetAllStatusQuery : IRequest<SuccessfulResponse>
    {


        public class GetAllStatusHandler : IRequestHandler<GetAllStatusQuery, SuccessfulResponse>
        {
            private readonly ResponseCode _responseCode;

            public GetAllStatusHandler(IOptions<ResponseCode> responseCode)
            {
                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetAllStatusQuery query, CancellationToken cancellationToken)
            {

                Dictionary<string, int> status = new Dictionary<string, int>();

                status.Add("AccountActivated", _responseCode.AccountActivated);

                status.Add("AccountSuspended", _responseCode.AccountSuspended);

                status.Add("BadRequest", _responseCode.BadRequest);

                status.Add("ClearedTaxes", _responseCode.ClearedTaxes);

                status.Add("Created", _responseCode.Created);

                status.Add("InternalServerError", _responseCode.InternalServerError);

                status.Add("InvalidPIN", _responseCode.InvalidPIN);

                status.Add("NoContent", _responseCode.NoContent);

                status.Add("NotAccepted", _responseCode.NotAccepted);

                status.Add("NotFound", _responseCode.NotFound);

                status.Add("OK", _responseCode.OK);

                status.Add("PendingTaxes", _responseCode.PendingTaxes);

                status.Add("POSActivated", _responseCode.POSActivated);
                
                status.Add("POSDeactivated", _responseCode.POSDeactivated);

                status.Add("RemittanceChecking", _responseCode.RemittanceChecking);

                status.Add("RemmitanceGenerated", _responseCode.RemmitanceGenerated);

                status.Add("TransactionFailed", _responseCode.TransactionFailed);

                status.Add("TransactionProcessing", _responseCode.TransactionProcessing);

                status.Add("TransactionRejected", _responseCode.TransactionRejected);

                status.Add("TransactionReversed", _responseCode.TransactionReversed);

                status.Add("TransactionSuccessful", _responseCode.TransactionSuccessful);

                status.Add("Unauthorized", _responseCode.Unauthorized);

                return new SuccessfulResponse()
                {
                    StatusCode = _responseCode.OK,

                    IsSuccess = true,

                    Message = "Successful",

                    Data = status
                };
            }


        }
    }
}

