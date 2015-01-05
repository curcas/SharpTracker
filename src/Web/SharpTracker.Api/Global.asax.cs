using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using SDammann.WebApi.Versioning;

namespace SharpTracker.Api
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

			// enable API versioning
			GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new RouteVersionedControllerSelector(GlobalConfiguration.Configuration));

			//MigrationConfig.SetInitializer();
		}
	}
}