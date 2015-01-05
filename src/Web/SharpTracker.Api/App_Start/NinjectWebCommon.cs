using SharpTracker.Core;
using SharpTracker.Core.Repositories;
using SharpTracker.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SharpTracker.Api.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SharpTracker.Api.NinjectWebCommon), "Stop")]

namespace SharpTracker.Api
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
			//TODO: Change this to InRequestScope. Currently shows an exception: 'The operation cannot be completed because the DbContext has been disposed.'
			kernel.Bind<SharpTrackerContext>().ToSelf().InSingletonScope();

			//Repositories
			kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
			kernel.Bind<ITokenRepository>().To<TokenRepository>().InRequestScope();
	        kernel.Bind<IWorkingTypeRepository>().To<WorkingTypeRepository>().InRequestScope();
        }        
    }
}
