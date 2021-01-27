using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.Collection;
using ErcasCollect.Commands.CollectionCommand;
using ErcasCollect.Commands.PosCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CollectionController : Controller
    {

        private readonly IMediator mediator;

        private readonly ILogger<Transaction> _logger;

        private readonly ResponseCode _responseCode;

        public CollectionController(ILogger<Transaction> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Pos Activation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Activation([FromBody] ActivatePosCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Pos user Login that return biller list of level one eg List of Mda's
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PosLogin([FromBody] PosLoginCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Pos user Log out
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PosLogout([FromBody] PosLogoutCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Listing category one service via pos eg revenue heads
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PosCategoryOneService([FromBody] PosCategoryOneCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Listing category two service via pos eg subheads heads
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PosCategoryTwoService([FromBody] PosCategoryTwoCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Cash collection from pos 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCollection([FromBody] CreateCollectionCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new ObjectResult(result);

                response.StatusCode = _responseCode.RemmitanceGenerated;

                return response;

                
            }
            catch (AppException ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An unknown error occurred on the make transaction action of the NonIgr");
                throw;
            }
        }

        /// <summary>
        /// Generate the total money collected for the period
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]    
        public async Task<IActionResult> GenerateRemittance([FromBody] GenerateRemittanceCommand request)
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
