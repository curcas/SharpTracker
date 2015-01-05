using System.Web.Http;

namespace SharpTracker.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				"DefaultApi",
				"api/v{version}/{controller}/{id}",
				new { id = RouteParameter.Optional }
			);

			// To disable tracing in your application, please comment out or remove the following line of code
			// For more information, refer to: http://www.asp.net/web-api
			config.EnableSystemDiagnosticsTracing();
		}
	}
}
