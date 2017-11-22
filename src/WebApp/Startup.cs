using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Company.Project.HelloClient;

namespace WebApp
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var container = new WindsorContainer();
            
			// *** Replaced by connected service ***
			
			//container.AddFacility<WcfFacility>();

            //container.Register(
            //    Component.For<IHelloService>()
            //             .AsWcfClient(WcfEndpoint.At("http://localhost:50214/HelloService.svc"))
            //             .LifestyleTransient()    
            //);

			// *** Connected Service ***

	        var helloServiceClient = new HelloServiceClient();
	        container.Register(Component.For<HelloServiceClient>().Instance(helloServiceClient));

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
