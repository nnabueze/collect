using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.DataAccess;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Report;
using ErcasCollect.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;

        private readonly ILogger<Biller> _logger;

        private readonly ResponseCode _responseCode;

        public ReportController(IMediator mediator, ILogger<Biller> logger, IOptions<ResponseCode> responseCode)
        {
            _mediator = mediator;

            _logger = logger;

            _responseCode = responseCode.Value;
        }

        /// <summary>
        /// Return HQ Total amount procced
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetHqTotalCount()
        {
            try
            {
                var result = await _mediator.Send(new GetHqTotalCountQuery());

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString(), "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

    }
}
