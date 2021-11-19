using Cotacoes.Api.Application.Configuration;
using Cotacoes.Infra.Data.SQLServer.Contexts;
using Cotacoes.Service.AutoMapper.v1;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cotacoes.Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFluentValidation();

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            #region Versionamento
            services.AddVersioning();
            #endregion

            #region Auto Mapper
            services.AddAutoMapperV1();
            #endregion

            #region Contexto EntityFramework
            services.AddDbContext<CotacaoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });
            #endregion

            #region Injeção de dependência
            services.Register();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguracao(Configuration);
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AllowCors(app);

            #region Swagger
            app.UseSwaggerConfiguration(provider);
            #endregion

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Versionamento
            app.UseVersioning();
            #endregion
        }

        private void AllowCors(IApplicationBuilder app)
        {
            app.UseCors(c =>
                        c.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
        }

    }
}
