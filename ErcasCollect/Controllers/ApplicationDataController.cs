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
        private readonly ILogger<Status> _logger;
        private readonly ResponseCode _responseCode;

        public ApplicationDataController(ILogger<Status> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _responseCode = responseCode.Value;
        }

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
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }


        [HttpGet("{id}")]
        public async Task<ReadAllMetaDataDto> GetMetaData(int id)
        {
            try
            {
                GetAllMetaDataQuery request = new GetAllMetaDataQuery();
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


        [HttpGet]
        
        public async Task<IEnumerable<ReadAllRolesDto>> GetAllRole()
        {
            try
            {
                GetAllRolesQuery request = new GetAllRolesQuery();

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
    
        public async Task<IEnumerable<ReadAllOs>> GetAllOs()
        {
            try
            {
                GetOsQuery request = new GetOsQuery();

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
       
        public async Task<IEnumerable<ReadPaymentChannelDto>> PaymentChannels()
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
       
        public async Task<IEnumerable<ReadAllBillerTypesDto>> BillerTypes()
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
      
        public async Task<IEnumerable<ReadAllBanksDto>> GetAllBanks()
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

        [HttpGet]

        public async Task<IEnumerable<ReadAllStatesDto>> AllStates()
        {
            try
            {
                GetAllStatesQuery request = new GetAllStatesQuery();

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
