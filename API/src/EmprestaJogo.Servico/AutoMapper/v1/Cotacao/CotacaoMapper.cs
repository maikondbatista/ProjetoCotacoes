using AutoMapper;
using Cotacoes.Domain.Dtos.v1;
using Cotacoes.Domain.Entities;

namespace Cotacoes.Service.AutoMapper.v1
{
    public class CotacaoMapper : Profile
    {
        public CotacaoMapper()
        {
            CreateMap<CotacaoDto, Cotacao>().ReverseMap();
            CreateMap<CotacaoItemDto, CotacaoItem>().ReverseMap();
        }
    }
}
