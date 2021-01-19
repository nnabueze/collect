using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.UserCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
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

        public UserController(ILogger<User> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: api/values
     

        // POST api/values
        [HttpPost]
      
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand request)
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
