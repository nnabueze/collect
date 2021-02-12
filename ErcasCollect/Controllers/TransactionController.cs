using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using ErcasCollect.Queries.Transaction;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TransactionController : Controller
    {
        private readonly IMediator mediator;

        private readonly ILogger<Transaction> _logger;

        private readonly INibssEbills _nibssEbills;

        private readonly IEbillsRemittance _ebillsRemittance;

        private readonly ResponseCode _responseCode;

        public TransactionController(ILogger<Transaction> logger, IMediator mediator, INibssEbills nibssEbills, IEbillsRemittance ebillsRemittance, 
            
            IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _nibssEbills = nibssEbills;

            _ebillsRemittance = ebillsRemittance;

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Verify close transaction detail  by passing close Transaction Id. eg Verify remittance Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> VerifyCloseBatchTransaction(string closeBatchTransactionId)
        {
            try
            {
                var result = await mediator.Send(new GetTransactionByBatchIDQuery(closeBatchTransactionId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString()});

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// All ebills valldations is received here!!
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ValidationResponse> EbillsValidation([FromBody]ValidationRequest request)
        {
            try
            {

                return await _nibssEbills.Validation(request);
            }
            catch (Exception ex)
            {

                return _ebillsRemittance.RemittanceFailedResponse(request, ex.Message.ToString());
            }
        }


        /// <summary>
        /// Get list of batch transactions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllBatchTransaction()
        {
            try
            {
                var result = await mediator.Send(new GetAllBatchTransactionQuery());

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get list of transactions by Batch Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllTransactionByBatchId(string batchId)
        {
            try
            {
                var result = await mediator.Send(new GetTransactionDetailByIDQuery(batchId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get list of batch transactions by biller Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllTransactionByBillerId(string billerId)
        {
            try
            {
                var result = await mediator.Send(new GetTransactionByBillerIDQuery(billerId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

    }
}
