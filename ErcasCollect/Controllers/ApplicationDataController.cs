using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    public class ApplicationDataController : Controller
    {
        // GET: /<controller>/
        private readonly IMediator mediator;
        private readonly ILogger<Status> _logger;

        public ApplicationDataController(ILogger<Status> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("GetStatus")]
        public async Task<IEnumerable<ReadStatusDto>> GetAllStatus()
        {
            try
            {
                GetAllStatusQuery request = new GetAllStatusQuery();

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
        [Route("GetPaymentChannel")]
        public async Task<IEnumerable<ReadPaymentChannelDto>> PaymentType()
        {
            try
            {
                GetAllPaymentChannelQuery request = new GetAllPaymentChannelQuery();

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
        [Route("GetTransactionType")]
        public async Task<IEnumerable<ReadAllTransactionTypes>> TransactionType()
        {
            try
            {
                GetAllTransactionTypesQuery request = new GetAllTransactionTypesQuery();

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
        [Route("GetBillerTypes")]
        public async Task<IEnumerable<ReadAllBillerTypes>> BillerTypes()
        {
            try
            {
                GetAllBillerTypesQuery request = new GetAllBillerTypesQuery();

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
        [Route("GetAllBanks")]
        public async Task<IEnumerable<ReadAllBanksDto>> Banks()
        {
            try
            {
                GetAllBanksQuery request = new GetAllBanksQuery();

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
