using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;
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

        public TransactionController(ILogger<Transaction> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<ReadTransactionDto>> GetTransactionBiller(string id)
        {
            try
            {
                GetTransactionByBillerIDQuery request = new GetTransactionByBillerIDQuery();
                request.id = id;
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
        public async Task<IEnumerable<ReadTransactionDto>> GetTransactionBatch(string id)
        {
            try
            {
                GetTransactionByBatchIDQuery request = new GetTransactionByBatchIDQuery();
                request.id = id;
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
        public async Task<ReadTransactionDto> GetTransactionByID(string id)
        {
            try
            {
                GetTransactionDetailByIDQuery request = new GetTransactionDetailByIDQuery();
                request.id = id;
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
        [Consumes("application/xml")]
        [Produces("application/xml")]
        [HttpPost]
        public async Task<ReadTransactionDto> Verify([FromBody]  ValidationRequest validation)
        {
            try
            {
                GetTransactionDetailByIDQuery request = new GetTransactionDetailByIDQuery();
                request.id = validation.RemitttanceID;
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
