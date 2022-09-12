using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sanalogi.Core.Entities;
using System.Linq;

namespace Siparis.API.Filters
{
    public class ValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(r => r.Errors).Select(r => r.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new ResponseEntity(errorMessage: errors.First())); //Burası düzeltilebilir.
            }
        }
    }
}
