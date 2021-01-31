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
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto.ReadTransactionDto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TransactionController : Controller
    {
        private readonly IMediator mediator;

        private readonly ILogger<Transaction> _logger;

        private readonly INibssEbills _nibssEbills;

        public TransactionController(ILogger<Transaction> logger, IMediator mediator, INibssEbills nibssEbills)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _nibssEbills = nibssEbills;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<ReadTransactionDto>> GetTransactionBiller(int id)
        {
            try
            {
                GetTransactionByBillerIDQuery request = new GetTransactionByBillerIDQuery();
                //request.id = id;
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<ReadTransactionDto>> GetTransactionBatch(int id)
        {
            try
            {
                GetTransactionByBatchIDQuery request = new GetTransactionByBatchIDQuery();
                //request.id = id;
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ReadTransactionDto> GetTransactionByID(string transactionNumber)
        {
            try
            {
                GetTransactionDetailByIDQuery request = new GetTransactionDetailByIDQuery();
                //request.transactionNumber = transactionNumber;
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
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
            catch (Exception)
            {

                return EbillsRemittance.RemittanceFailedResponse(request);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ReadTransactionDto>> GetAllTransaction()
        {
            try
            {
                GetTransactionForAdminQuery request = new GetTransactionForAdminQuery();
            
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
            }
        }


    }
}
