using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Commands.LevelThreeCommand;
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
    public class LevelThreeController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<LevelThree> _logger;

        public LevelThreeController(ILogger<LevelThree> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: api/values

        // POST api/values
        [HttpPost]
     
        public async Task<ActionResult> CreateLevelThree([FromBody] CreateLevelThreeCommand request)
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

        [HttpGet("{id}")]

        public async Task<IEnumerable<ReadLevelThreeDto>> GetAllLevelThreeByBiller(int id)
        {
            try
            {
                GetAllLevelThreeByBillerQuery request = new GetAllLevelThreeByBillerQuery();
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

        public async Task<ReadLevelThreeDto> GetAllLevelThreeByID(int id)
        {
            try
            {
                GetAllLevelThreeByIDQuery request = new GetAllLevelThreeByIDQuery();
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
