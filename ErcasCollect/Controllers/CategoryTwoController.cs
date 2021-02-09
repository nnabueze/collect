using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.CategoryOnCommand;
using ErcasCollect.Commands.CategoryTwoCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.CategoryOneQuery;
using ErcasCollect.Queries.CategoryTwoQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryTwoController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<LevelOne> _logger;

        private readonly ResponseCode _responseCode;

        public CategoryTwoController(IMediator mediator, ILogger<LevelOne> logger, IOptions<ResponseCode> responseCode)
        {
            _mediator = mediator;

            _logger = logger;

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Adding category two  eg adding subheads heads on the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoryTwo([FromBody] CreateCategoryTwoCommand request)
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
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }

        /// <summary>
        /// Updating category two records
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateCategoryTwo([FromBody] UpdateCategoryTwoCommand request)
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
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the make transaction action of the NonIgr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;

            }
        }


        /// <summary>
        /// Listing all category two by category one eg revenue to subhead head
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoryOne(string billerId, string categoryOneId)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoryTwoByCategoryQuery(billerId, categoryOneId));

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
        /// Listing all category two by biller Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryTwoByBiller(string billerId)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoryTwoByBillerIdQuery(billerId));

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
    }
}
