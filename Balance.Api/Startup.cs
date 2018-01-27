using System;
using System.Net;
using Amazon;
using Balance.Infrastructure.Models;
using Domain.Balance;
using JustSaying;
using JustSaying.AwsTools;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel;
using SharedKernel.Decorators;
using SharedKernel.Domain;
using SharedKernel.Domain.IntegrationEvents;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace Balance.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Docker API", Version = "v1" });
            });

            services.AddMvc()
                .AddControllersAsServices();

            return ConfigureIoC(services);
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Policies.Interceptors(new RepositoryEventPublishDecorationPolicy());
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AddAllTypesOf(typeof(JustSaying.Messaging.MessageHandling.IHandlerAsync<>));

                    config.For<IMediator>().Use<Mediator>();
                    _.AddAllTypesOf(typeof(IRequestHandler<,>));
                    _.AddAllTypesOf(typeof(INotificationHandler<>));
                    _.AddAllTypesOf(typeof(AsyncNotificationHandler<>));

                    config.For<EventSourcingContext>().Use<EventSourcingContext>();
                    //config.For<IAggregateFactory>().Use<UserFactory>();

                    _.AddAllTypesOf(typeof(IEventRepository<>));
                    _.AddAllTypesOf(typeof(IAggregateFactory<>));
                    config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                    config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

                    config.For(typeof(IPipelineBehavior<,>)).Add(typeof(GenericPipelineBehaviour<,>));

                    _.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    _.WithDefaultConventions();
                });

                //Populate the container using the service collection
                config.Populate(services);
            });

            CreateMeABus.DefaultClientFactory = () =>
          new DefaultAwsClientFactory(
              new Amazon.Runtime.BasicAWSCredentials(
                  "",
                  ""));

            CreateMeABus
            .WithLogging(new Microsoft.Extensions.Logging.LoggerFactory())
           .InRegion(RegionEndpoint.SAEast1.SystemName)
           .WithSqsTopicSubscriber()
           .IntoQueue("CustomerOrders")
           .WithMessageHandler<UserRegistered>(new StructureMapHandlerResolver(container))
           .StartListening();

            return container.GetInstance<IServiceProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(
             options =>
             {
                 options.Run(
                 async context =>
                 {
                     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                     context.Response.ContentType = "text/html";
                     var ex = context.Features.Get<IExceptionHandlerFeature>();
                     if (ex != null)
                     {
                         var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                         await context.Response.WriteAsync(err).ConfigureAwait(false);
                     }
                 });
             }
            );

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Docker API");
            });
        }
    }

    

    
}
