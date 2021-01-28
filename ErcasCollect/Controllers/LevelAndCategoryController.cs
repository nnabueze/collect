using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.BranchCommand;
using ErcasCollect.Commands.LevelOneCommand;
using ErcasCollect.Commands.LevelTwoCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelAndCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly ILogger<LevelOne> _logger;

        private readonly ResponseCode _responseCode;

        public LevelAndCategoryController(IMediator mediator, ILogger<LevelOne> logger, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator;

            _logger = logger;

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

        //[HttpGet]

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

        //// GET api/values/5
        //[HttpGet]
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

        //[HttpGet]
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
    }
}
