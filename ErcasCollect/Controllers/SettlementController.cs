using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.SettlementCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SettlementController : Controller
    {
        private readonly IMediator _mediator;

        private readonly ILogger<Settlement> _logger;

        private readonly ResponseCode _responseCode;

        public SettlementController(ILogger<Settlement> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode.Value;
        }
        // GET: api/values


        [HttpPost]

        public async Task<ActionResult> CreateSettlement([FromBody] CreateSettlementCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return new JsonResult(result);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
               
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> FlexSettlement([FromBody] FlexSettlementCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }

        }


    }
}
