using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.osQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApplicationDataController : Controller
    {
        // GET: /<controller>/
        private readonly IMediator mediator;

        private readonly ILogger<ApplicationDataController> _logger;

        private readonly ResponseCode _responseCode;

        public ApplicationDataController(IMediator mediator, IOptions<ResponseCode> responseCode, ILogger<ApplicationDataController> logger)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _responseCode = responseCode.Value;

            _logger = logger;
        }


        /// <summary>
        /// Listing all system status response
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllStatus()
        {
            try
            {
                GetAllStatusQuery request = new GetAllStatusQuery();

                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get all status");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get list of roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IEnumerable<ReadAllRolesDto>> GetAllRole()
        {
            try
            {
                GetAllRolesQuery request = new GetAllRolesQuery();

                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get all roles");
                
                throw;
            }
        }

        /// <summary>
        /// List of payment channels
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public async Task<IEnumerable<ReadPaymentChannelDto>> PaymentChannels()
        {
            try
            { 

                return await mediator.Send(new GetAllPaymentChannelQuery());
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "Payment channels");
               
                throw;
            }
        }


        /// <summary>
        /// Get system transaction type
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public async Task<IEnumerable<ReadAllTransactionTypes>> TransactionType()
        {
            try
            {
                GetAllTransactionTypesQuery request = new GetAllTransactionTypesQuery();

                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "List of transaction type");
                
                throw;
            }
        }

        /// <summary>
        /// Get system billers
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public async Task<IEnumerable<ReadAllBillerTypesDto>> BillerTypes()
        {
            try
            {
                GetAllBillerTypesQuery request = new GetAllBillerTypesQuery();

                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Biller types");
               
                throw;
            }
        }

        /// <summary>
        /// List al states
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ReadAllStatesDto>> AllStates()
        {
            try
            {
                GetAllStatesQuery request = new GetAllStatesQuery();

                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "All states");
               
                throw;
            }
        }
    }
}
