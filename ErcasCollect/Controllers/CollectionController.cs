using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.CollectionCommand;
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
        // GET: api/values

    }
    
}
