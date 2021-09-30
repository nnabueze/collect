using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.CategoryOnCommand;
using ErcasCollect.Commands.LevelOneCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.CategoryOneQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryOneController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<LevelOne> _logger;

        private readonly ResponseCode _responseCode;

        public CategoryOneController(IMediator mediator, ILogger<LevelOne> logger, IOptions<ResponseCode> responseCode)
        {
            _mediator = mediator;

            _logger = logger;

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Adding category one  eg adding revenue heads on the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoryOne([FromBody] CreateCategoryOneCommand request)
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
                _logger.LogError(ex, "CreateCategoryOne");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Updating category one records
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateCategoryOne([FromBody] UpdateCategoryOneCommand request)
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
                _logger.LogError(ex, "UpdateCategoryOn");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }


        /// <summary>
        /// Listing all category one by level one eg mda to renvenue head
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoryOne(string billerId, string levelOneId)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoryOneByLevelQuery(billerId, levelOneId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCategoryOne");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }
    }
}
