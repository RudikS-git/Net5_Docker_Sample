using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Startup
    {
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration configuration) => _cfg = configuration;

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            await app.UseOcelot();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddOcelot();
         //   var identityUrl = _cfg.GetValue<string>("IdentityUrl");
         //   var authenticationProviderKey = "IdentityApiKey";

        }
    }
}