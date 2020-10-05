using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.UserCommand;
using ErcasCollect.Domain.Models;
using ErcasCollect.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers
{
    [Route("api/user")]
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
        [HttpGet]
        [Route("getall")]
        public IEnumerable<string> GetAllUsers(string status, int role, string billerid, string department, string branch )
        {
            return new string[] { "value1", "value2" };
        }

 

        // GET api/values/5
        [HttpGet]
        [Route("byid")]
        public string GetUserbyId(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("createuser")]
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

        // PUT api/values/5
        [HttpPut]
        [Route("update")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
