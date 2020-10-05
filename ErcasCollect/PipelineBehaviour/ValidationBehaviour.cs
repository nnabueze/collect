using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErcasCollect.PipelineBehaviour
{
    public class ValidationBehaviour: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new Error()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }
    }

    public class Error
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
        public string[] ValidValues { get; set; }
    }
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(Error error)
        {
            Errors.Add(error);
        }

        public List<Error> Errors { get; set; } = new List<Error>();


    }
}