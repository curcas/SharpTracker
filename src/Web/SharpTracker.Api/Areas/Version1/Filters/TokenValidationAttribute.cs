using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject;
using SharpTracker.Core.Repositories;

namespace SharpTracker.Api.Areas.Version1.Filters
{
	public class TokenValidationAttribute : ActionFilterAttribute
	{
		[Inject]
		public ITokenRepository TokenRepository { get; set; }

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			var tokenHeader = actionContext.Request.Headers.FirstOrDefault(p => p.Key == "Token");

			if (string.IsNullOrEmpty(tokenHeader.Key))
			{
				actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token header is missing.");
				return;
			}

			if (string.IsNullOrEmpty(tokenHeader.Value.FirstOrDefault()))
			{
				actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token is missing.");
				return;
			}

			if (TokenRepository.Get(tokenHeader.Value.First()) == null)
			{
				actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token is invalid.");
			}
		}
	}
}