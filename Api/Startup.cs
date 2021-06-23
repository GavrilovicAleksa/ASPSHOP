using Api.Core;
using Api.Core.Requests;
using Application;
using Application.Commands.Brand;
using Application.Commands.Cart;
using Application.Commands.Order;
using Application.Commands.Photo;
using Application.Commands.Product;
using Application.Commands.User;
using Application.Queries.Brand;
using Application.Queries.Cart;
using Application.Queries.Order;
using Application.Queries.Product;
using Application.Queries.User;
using Application.Searches;
using DataAccess;
using Implementation.Commands.Brand;
using Implementation.Commands.Cart;
using Implementation.Commands.Order;
using Implementation.Commands.Product;
using Implementation.Commands.User;
using Implementation.Logging;
using Implementation.Queries.Brand;
using Implementation.Queries.Cart;
using Implementation.Queries.Order;
using Implementation.Queries.Product;
using Implementation.Queries.User;
using Implementation.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var httpContext = accessor.HttpContext;

                if(httpContext == null)
                {
                    return new AnonymousActor();
                }

                var user = httpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
            services.AddTransient<Context>();
            services.AddTransient<LoginRequest>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetSingleUserQuery, EfGetSingleUserQuery>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ISearchBrandsQuery, EfSearchBrandsQuery>();
            services.AddTransient<IGetSingleBrandQuery, EfGetSingleBrandQuery>();
            services.AddTransient<ICreateBrandCommand, EfInsertBrandCommand>();
            services.AddTransient<IRemoveBrandCommand, EfRemoveBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<IGetCartQuery, EfGetCartQuery>();
            services.AddTransient<IAddCartItemCommand, EfAddCartItemCommand>();
            services.AddTransient<IRemoveCartItemCommand, EfRemoveCartItemCommand>();
            services.AddTransient<IGetOrderQuery, EfGetOrderQuery>();
            services.AddTransient<IAddOrderItemCommand, EfCreateOrderCommand>();
            services.AddTransient<IRemoveOrderCommand, EfRemoveOrderCommand>();
            services.AddTransient<ISearchPhotosQuery, EfSearchPhotosQuery>();
            services.AddTransient<IGetSinglePhotoQuery, EfGetSinglePhotoQuery>();
            services.AddTransient<ICreatePhotoCommand, EfInsertPhotoCommand>();
            services.AddTransient<IRemovePhotoCommand, EfRemovePhotoCommand>();
            services.AddTransient<IUpdatePhotoCommand, EfUpdatePhotoCommand>();
            services.AddTransient<ISearchProductsQuery, EfSearchProductsQuery>();
            services.AddTransient<IGetSingleProductQuery, EfGetSingleProductQuery>();
            services.AddTransient<IRemoveProductCommand, EfRemoveProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<JwtManager>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<UserSearch>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
