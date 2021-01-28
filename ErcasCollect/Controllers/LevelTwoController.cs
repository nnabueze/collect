using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ErcasCollect.Commands.LevelTwoCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LevelTwoController : Controller
    {

        private readonly IMediator mediator;

        private readonly ILogger<LevelTwo> _logger;

        private readonly ResponseCode _responseCode;

        public LevelTwoController(ILogger<LevelTwo> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Add level two into the system that is create station's
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateLevelTwo([FromBody] CreateLevelTwoCommand request)
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


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<ReadLevelTwoDto>> GetAllLevelTwoByBiller(int id)
        //{
        //    try
        //    {
        //        GetAllLevelTwoByBillerQuery request = new GetAllLevelTwoByBillerQuery();
        //        request.id = id;
        //        return await mediator.Send(request);
        //    }
        //    catch (AppException ex)
        //    {
        //        _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
        //        // return await BadRequest(new { message = ex.Message });
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
        //        throw;
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<ReadLevelTwoDto> GetAllLevelTwoByID(int id)
        //{
        //    try
        //    {
        //        GetAllLevelTwoByIdQuery request = new GetAllLevelTwoByIdQuery();
        //        request.id = id;
        //        return await mediator.Send(request);
        //    }
        //    catch (AppException ex)
        //    {
        //        _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
        //        // return await BadRequest(new { message = ex.Message });
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
        //        throw;
        //    }
        //}

        //// POST api/values
        //[HttpPost]

        //public async Task<ActionResult> CreateLevelTwo([FromBody] CreateLevelTwoCommand request)
        //{
        //    try
        //    {
        //        var result = await mediator.Send(request);
        //        return new JsonResult(result);
        //    }
        //    catch (AppException ex)
        //    {
        //        _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
        //        // return await BadRequest(new { message = ex.Message });
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An unknown error occurred on the make transaction action of the NonIgr");
        //        throw;
        //    }
        //}


        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
