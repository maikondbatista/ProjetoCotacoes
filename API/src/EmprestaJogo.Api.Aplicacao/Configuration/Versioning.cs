using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cotacoes.Api.Application.Configuration
{
    public static class Versioning
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;

            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });

        }

        public static void UseVersioning(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseMvc()
               .UseApiVersioning()
               .UseMvcWithDefaultRoute();
        }
    }
}
