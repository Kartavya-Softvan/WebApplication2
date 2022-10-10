using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Service;

namespace WebApplication2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomTokenRequestValidator, DefaultClientClaimsAdder>();
            services.AddIdentityServer()
                .AddInMemoryClients(IdentityConfiguration.Clients)
                .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
                .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                .AddTestUsers(IdentityConfiguration.TestUsers)
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
    public class DefaultClientClaimsAdder : ICustomTokenRequestValidator
    {
        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
            switch (context.Result.ValidatedRequest.Client.ClientId)
            {
                case "c1.client":
                    context.Result.ValidatedRequest.ClientClaims.Add(new Claim("policy", "client1_Policy"));
                    break;
                case "c2.client":
                    context.Result.ValidatedRequest.ClientClaims.Add(new Claim("policy", "client2_Policy"));
                    break;

                default:
                    break;
            }
            return Task.FromResult(0);
        }
    }
}
