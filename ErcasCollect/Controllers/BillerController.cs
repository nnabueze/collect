using System;
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

        private readonly ILogger<BillerController> _logger;

        private readonly ResponseCode _responseCode;

        public BillerController(IMediator mediator, IOptions<ResponseCode> responseCode, ILogger<BillerController> logger)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _responseCode = responseCode.Value;

            _logger = logger;
        }

        /// <summary>
        /// Adding biller on the platform setting isGatwayOnboard to true onboard the biller on api gateway. Point gateway to live server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                _logger.LogError(ex, "Creating biller");

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
                _logger.LogError(ex, "Update biller");

                var response = new JsonResult(new { Message = ex.Message.ToString()});

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Add ebills validation parameter for a specifie biller onboarded on api gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddEbillsValidationParameter([FromBody] EbillsValidationCommand request)
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
                _logger.LogError(ex, "Adding ebills parameter");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Add biller display names
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddBillerDsplayName([FromBody] AddBillerDisplayNameCommand request)
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
                _logger.LogError(ex, "add Biller display name");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get displayname by biller Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBillerDsplayName(string billerId)
        {
            try
            {
                var result = await mediator.Send(new GetBillerDisplayNameQuery(billerId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get display name");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Add ebills notification parameter for a specifie biller onboarded on api gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddEbillsNotificationParameter([FromBody] EbillsNotificationCommand request)
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
                _logger.LogError(ex, "Add ebills notification parataer");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }



        /// <summary>
        /// Add ebills product for a specific biller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> AddEbillsBillerProduct([FromBody] EbillsBillerProductCommand request)
        //{
        //    try
        //    {
        //        var result = await mediator.Send(request);

        //        var response = new JsonResult(result);

        //        response.StatusCode = result.StatusCode;

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "add ebills product");

        //        var response = new JsonResult(new { Message = ex.Message.ToString() });

        //        response.StatusCode = _responseCode.InternalServerError;

        //        return response;
        //    }
        //}




        /// <summary>
        /// Get a single biler bybille Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBillerByID(string id)
        {
            try
            {
                GetBillerByIDQuery request = new GetBillerByIDQuery();

                request.id = id;

                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get biller byId");

                var response = new JsonResult(new { Message = ex.Message.ToString()});

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// List active biller on the paltform
        /// </summary>
        /// <returns></returns>

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
                _logger.LogError(ex, "GetAllBillers");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }


        /// <summary>
        /// List billers by category eg Igr, School, etc
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet("{id}")]

        public async Task<ActionResult> GetAllBillersByCategory(int id)
        {
            try
            {
                GetAllBillerByCategoryQuery request = new GetAllBillerByCategoryQuery();

                request.id = id;

                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllBillersCategory");

                var response = new JsonResult(new { Message = ex.Message.ToString()});

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// List billers ebills product by billerId
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]

        public async Task<ActionResult> GetAllBillersEbillsProduct(string id)
        {
            try
            {
                GetAllBillerEbillsProduct request = new GetAllBillerEbillsProduct();

                request.Id = id;

                var result = await mediator.Send(request);

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get all Bille product");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get list of all ercas ebills products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetErcasEbillsProduct()
        {
            try
            {
                var result = await mediator.Send(new GetAllErcasEbillsProductQuery());

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Ercas eBills product");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }

        /// <summary>
        /// Get list biller validation parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBillerValidationParameter(string BillerId)
        {
            try
            {
                var result = await mediator.Send(new GetBillerValidationParameterQuery(BillerId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }


        /// <summary>
        /// Get list biller notification parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBillerNotificationParameter(string BillerId)
        {
            try
            {
                var result = await mediator.Send(new GetBillerNotificationParameterQuery(BillerId));

                var response = new JsonResult(result);

                response.StatusCode = result.StatusCode;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Application exception occurred on the Get Specific action of the Igr");

                var response = new JsonResult(new { Message = ex.Message.ToString() });

                response.StatusCode = _responseCode.InternalServerError;

                return response;
            }
        }
    }
}
