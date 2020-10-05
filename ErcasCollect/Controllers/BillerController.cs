using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.BillerCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/biller")]
    public class BillerController : Controller
    {
        // GET: api/values
        private readonly IMediator mediator;
        private readonly ILogger<Biller> _logger;

        public BillerController(ILogger<Biller> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpPost]
        [Route("CreateBiller")]
        public async Task<ActionResult> CreateBiller([FromBody] CreateBillerCommand request)
        {
            try
            {
                var result = await mediator.Send(request);
                return new JsonResult(result);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the make transaction action of the NonIgr");
                throw;
            }
        }

        [HttpPost]
        [Route("Addbank")]
        public async Task<ActionResult> CreateBank([FromBody] CreateBillerBankCommand request)
        {
            try
            {
                var result = await mediator.Send(request);
                return new JsonResult(result);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the make transaction action of the NonIgr");
                throw;
            }
        }

        [HttpPost]
        [Route("AddTinDetail")]
        public async Task<ActionResult> CreateTIN([FromBody] CreateTinCommand request)
        {
            try
            {
                var result = await mediator.Send(request);
                return new JsonResult(result);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the make transaction action of the NonIgr");
                throw;
            }
        }

        [HttpGet]
        [Route("GetBillerByID")]
        public async Task<ActionResult> GetBillerByID(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBillers")]
        public async Task<ActionResult> GetAllBillers(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetBillerByStatus")]
        public async Task<ActionResult> GetBillerByStatus(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetBillerByType")]
        public async Task<ActionResult> GetBillerByType(int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBiller")]
        public async Task<ActionResult> DeleteBiller(int id)
        {
            return Ok();
        }


    }
}
