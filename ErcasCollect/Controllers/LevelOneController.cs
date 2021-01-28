using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.BranchCommand;
using ErcasCollect.Commands.LevelOneCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LevelOneController : Controller
    {

        private readonly IMediator mediator;

        private readonly ILogger<LevelOne> _logger;

        private readonly ResponseCode _responseCode;

        public LevelOneController(ILogger<LevelOne> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode.Value;
        }


        /// <summary>
        /// Add level one into the system that is create mda's
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateLevelOne([FromBody] CreateLevelOneCommand request)
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
        /// Updating level one records
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateLevelOne([FromBody] UpdateLevelOneCommand request)
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
        /// Listing all level one by biller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLevelOne(string billerId)
        {
            try
            {
                GetAllLevelOneByBillerQuery request = new GetAllLevelOneByBillerQuery();

                request.billerId = billerId;

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









        //[HttpPost]

        //public async Task<ActionResult> CreateLevelOne([FromBody] CreateLevelOneCommand request)
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
        // GET: api/values
        //[HttpGet("{id}")]

        //public async Task<IEnumerable<ReadLevelOneDto>> GetAllLevelOneByBiller(int id)
        //{
        //    try
        //    {
        //        GetAllLevelOneByBillerQuery request = new GetAllLevelOneByBillerQuery();
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

        //public async Task<ReadLevelOneDto> GetAllLevelOneByID(int id)
        //{
        //    try
        //    {
        //        GetAllLevelOneByIDQuery request = new GetAllLevelOneByIDQuery();
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

    }
}
