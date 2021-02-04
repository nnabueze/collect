﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.UserCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.BillerQuery;
using ErcasCollect.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        private readonly ILogger<User> _logger;

        private readonly ResponseCode _responseCode;

        public UserController(ILogger<User> logger, IMediator mediator, ResponseCode responseCode)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _responseCode = responseCode;
        }

        /// <summary>
        /// Create user on the platform
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]      
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                //response.StatusCode = result.StatusCode;

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


        [HttpGet]
      
        public async Task<IEnumerable<ReadUserDto>> GetAllUsers()
        {
            try
            {
                GetAllUsersQuery request = new GetAllUsersQuery();

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

        [HttpGet("{id}")]
        public async Task<ReadUserDto> GetUserByID(int id)
        {
            try
            {
                GetUserByIDQuery request = new GetUserByIDQuery();
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
        [HttpGet("{id}")]
        public async Task<ReadUserDto> GetUserBySsoID(int id)
        {
            try
            {
                GetUserBySsoIDQuery request = new GetUserBySsoIDQuery();
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

        [HttpGet("{id}")]
        public async Task<IEnumerable<ReadUserDto>> GetUserByBiller(int id)
        {
            try
            {
                GetAllUserByBillerQuery request = new GetAllUserByBillerQuery();
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
