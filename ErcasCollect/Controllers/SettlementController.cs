using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.SettlementCommand;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.Nibss;
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

        private readonly INibssEbills _nibssEbills;

        public SettlementController(ILogger<Settlement> logger, IMediator mediator, IOptions<ResponseCode> responseCode, INibssEbills nibssEbills)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode.Value;

            _nibssEbills = nibssEbills;
        }
        // GET: api/values

        /// <summary>
        /// Ebills notification endpoint for all biller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<NotificationResponse> EbillsNotification([FromBody] NotificationRequest request)
        {
            try
            {
                return await _nibssEbills.Notification(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
               
                throw;
            }
        }

        /// <summary>
        /// Self service notification endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
