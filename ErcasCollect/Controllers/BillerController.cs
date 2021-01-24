﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ercas.Pay.Service.Commands;
using ErcasCollect.Commands.BillerCommand;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BillerController : Controller
    {
        // GET: api/values
        private readonly IMediator mediator;
        private readonly ILogger<Biller> _logger;
        private readonly ResponseCode _responseCode;

        public BillerController(ILogger<Biller> logger, IMediator mediator, IOptions<ResponseCode> responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _responseCode = responseCode.Value;
        }
        [HttpPost]

        public async Task<ActionResult> CreateBiller([FromBody] CreateBillerCommand request)
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
        /// Update  Biller Detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns>uthj</returns>
        [HttpPut]

        public async Task<ActionResult> UpdateBiller([FromBody] UpdateBillerDetailCommand request)
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

                var response = new JsonResult(new { Message = ex.Message.ToString()});

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        //[HttpPost]
      
        //public async Task<IActionResult> AddBank([FromBody] CreateBillerBankCommand request)
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

        [HttpPost]
       
        //public async Task<ActionResult> CreateTIN([FromBody] CreateTinCommand request)
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




        [HttpGet("{id}")]
        public async Task<ReadBillerDto> GetBillerByID(string id)
        {
            try
            {
                GetBillerByIDQuery request = new GetBillerByIDQuery();
                request.id = id;
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
            }
        }


        [HttpGet]

        public async Task<ActionResult> GetAllBillers()
        {
            try
            {
                GetAllBillerQuery request = new GetAllBillerQuery();

                var result = await mediator.Send(request);

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

        [HttpGet("{id}")]

        public async Task<IEnumerable<ReadBillerDto>> GetAllBillersByCategory(int id)
        {
            try
            {
                GetAllBillerByCategoryQuery request = new GetAllBillerByCategoryQuery();
                request.id = id;
                return await mediator.Send(request);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");
                // return await BadRequest(new { message = ex.Message });
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred on the Get Specific action of the Igr");
                throw;
            }
        }

     




    }
}
