using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Green.Core.Configuration;
using Green.Core.Infrastructure;
using Green.Web.Framework.Infrastructure.Extensions;
using Green.Data;

namespace Green.Web.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring common features and middleware on application startup
    /// </summary>
    public class GreenCommonStartup : IGreenStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
           

            //add GreenConfig configuration parameters
            var greenConfig = services.ConfigureStartupConfig<GreenConfig>(configuration.GetSection("Green"));

			//add data layer
            services.AddDbContext<GreenObjectContext>(options => options.UseSqlServer(greenConfig.SqlConnectionString));


			//add accessor to HttpContext
			services.AddHttpContextAccessor();

            //add HTTP sesion state feature
            services.AddHttpSession();

            //add anti-forgery
            services.AddAntiForgery();

        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //static files
            var greenConfig = EngineContext.Current.Resolve<GreenConfig>();
            application.UseStaticFiles();
           
            //use HTTP session
            application.UseSession();

        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //common services should be loaded after error handlers
            get { return 100; }
        }
    }
}
