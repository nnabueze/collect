using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.SettlementCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SettlementController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<Settlement> _logger;

        public SettlementController(ILogger<Settlement> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: api/values
  

        [HttpPost]

        public async Task<ActionResult> CreateSettlement([FromBody] CreateSettlementCommand request)
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


    }
}
