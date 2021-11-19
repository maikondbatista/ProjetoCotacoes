using Cotacoes.Domain.Entities;
using Cotacoes.Domain.Interfaces.Repositories;
using Cotacoes.Domain.Interfaces.Services.v1;
using Cotacoes.Domain.Validations;
using Cotacoes.Infra.Data.SQLServer.Repositories;
using Cotacoes.Servico.Servicos.v1;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Cotacoes.Api.Application.Configuration
{
    public static class DependencyInjection
    {
        public static void Register(this IServiceCollection services)
        {
            #region Serviço
            services.AddScoped<ICotacaoService, CotacaoService>();
            #endregion

            #region Repositorio
            services.AddScoped<ICotacaoItemRepository, CotacaoItemRepository>();
            services.AddScoped<ICotacaoRepository, CotacaoRepository>();
            #endregion

            #region Validação
            services.AddTransient<IValidator<Cotacao>, CotacaoValidator>();
            services.AddTransient<IValidator<CotacaoItem>, CotacaoItemValidator>();

            #endregion

            #region Http
            services.AddTransient<HttpClient, HttpClient>();
            #endregion
        }
    }
}
