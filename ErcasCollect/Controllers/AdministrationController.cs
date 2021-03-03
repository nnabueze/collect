using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ercas.Pay.Service.Commands;
using ErcasCollect.Exceptions;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErcasCollect.Controllers {
    [Route("api/[controller]/[action]")]
    public class AdministrationController : Controller
    {


        private readonly IMediator mediator;
    

        public AdministrationController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
           
        }

        //[HttpDelete("{id}")]
      
        //public async Task<SuccessfulResponse> DeleteBiller( string id)
        //{
        //    try
        //    {
        //        DeleteBillerCommand request = new DeleteBillerCommand();
        //        request.id = id;
        //        return await mediator.Send(request);
        //    }
        //    catch (AppException ex)
        //    {
        //      //  _logger.LogError(ex, "An Application exception occurred on the make transaction action of the NonIgr");
        //        // return await BadRequest(new { message = ex.Message });
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //      //  _logger.LogError(ex, "An unknown error occurred on the make transaction action of the NonIgr");
        //        throw;
        //    }
        //}

    }
}
