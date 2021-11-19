using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Cotacoes.Service.AutoMapper.v1
{
    public static class AutoMapperConfigurationV1
    {
        public static void AddAutoMapperV1(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CotacaoMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
