﻿using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lykke.Common.ApiLibrary.Middleware;
using Lykke.Common.ApiLibrary.Swagger;
using Lykke.Logs;
using Lykke.Service.EthereumSignService.Core.Exceptions;
using Lykke.Service.EthereumSignService.Core.Services;
using Lykke.Service.EthereumSignService.Models;
using Lykke.Service.EthereumSignService.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.EthereumSignService
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Environment = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });

            services.AddSwaggerGen(options =>
            {
                options.DefaultLykkeConfiguration("v1", "EthereumSignService");
            });

            services.AddEmptyLykkeLogging();

            var builder = new ContainerBuilder();

            builder.RegisterModule(new ServiceModule());
            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseLykkeMiddleware(ex =>
            {
                if (ex is ClientSideException clientError)
                {
                    var response = ErrorResponse.Create();
                    response.AddModelError(clientError.Type.ToString(), clientError);

                    return response;
                }

                return new { Message = "Technical problem" };
            });

            app.UseMvc();
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = "swagger/ui";
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            app.UseStaticFiles();

            appLifetime.ApplicationStarted.Register(() => StartApplication().GetAwaiter().GetResult());
            appLifetime.ApplicationStopping.Register(() => StopApplication().GetAwaiter().GetResult());
            appLifetime.ApplicationStopped.Register(CleanUp);
        }

        private async Task StartApplication()
        {
            // NOTE: Service not yet recieve and process requests here

            await ApplicationContainer.Resolve<IStartupManager>().StartAsync();
        }

        private async Task StopApplication()
        {
            // NOTE: Service still can recieve and process requests here, so take care about it if you add logic here.

            await ApplicationContainer.Resolve<IShutdownManager>().StopAsync();
        }

        private void CleanUp()
        {
            // NOTE: Service can't recieve and process requests here, so you can destroy all resources

            ApplicationContainer.Dispose();
        }
    }
}
