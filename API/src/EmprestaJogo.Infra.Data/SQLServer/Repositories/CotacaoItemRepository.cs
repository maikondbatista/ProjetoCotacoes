using Cotacoes.Domain.Entities;
using Cotacoes.Domain.Interfaces.Repositories;
using Cotacoes.Infra.Data.SQLServer.Contexts;

namespace Cotacoes.Infra.Data.SQLServer.Repositories
{
    public class CotacaoItemRepository : RepositoryBase<CotacaoItem>, ICotacaoItemRepository
    {
        public CotacaoItemRepository(CotacaoContext contexto) : base(contexto)
        { }
    }
}
