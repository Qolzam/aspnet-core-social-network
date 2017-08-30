using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Green.Core.Infrastructure;
using Green.Services.Authentication;
using Green.Services.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Green.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        /// <returns>Configured service provider</returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            //create, initialize and configure the engine
            var engine = EngineContext.Create();
            engine.Initialize(services);
            var serviceProvider = engine.ConfigureServices(services, configuration);

            //TODO: Check if database is installed

                //implement schedule tasks
                //database is already installed, so start scheduled tasks
                TaskManager.Instance.Initialize();
                TaskManager.Instance.Start();


            return serviceProvider;
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            //override cookie name
            services.AddAntiforgery(options =>
            {
                options.Cookie = new CookieBuilder()
                {
                    Name = ".Green.Antiforgery"

                };


            });
        }

        /// <summary>
        /// Adds services required for application session state
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie = new CookieBuilder()
                {
                    Name=".Green.Session",
                    HttpOnly = true
                        
                };
            });
        }


        /// <summary>
        /// Adds authentication service
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddGreenAuthentication(this IServiceCollection services)
        {
			services.AddAuthentication(options =>
			{
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

			});
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.AccessDeniedPath = GreenCookieAuthenticationDefaults.AccessDeniedPath;
                        options.LoginPath = GreenCookieAuthenticationDefaults.LoginPath;
                        options.Cookie = new CookieBuilder()
                        {
                            HttpOnly = true,
                            Name = GreenCookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationScheme,

                        };

		 });

        }

		/// <summary>
		/// Add and configure MVC for the application
		/// </summary>
		/// <param name="services">Collection of service descriptors</param>
		/// <returns>A builder for configuring MVC services</returns>
		public static IMvcBuilder AddGreenMvc(this IServiceCollection services)
		{
			//add basic MVC feature
			var mvcBuilder = services.AddMvc();

			//MVC now serializes JSON with camel case names by default, use this code to avoid it
			//mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



			return mvcBuilder;
		}
    }
}
