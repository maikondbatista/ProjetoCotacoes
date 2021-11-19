using Cotacoes.Domain.Entities;
using Cotacoes.Domain.Interfaces.Repositories;
using Cotacoes.Infra.Data.SQLServer.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cotacoes.Infra.Data.SQLServer.Repositories
{
    public class CotacaoRepository : RepositoryBase<Cotacao>, ICotacaoRepository
    {
        private readonly CotacaoContext _contexto;
        public CotacaoRepository(CotacaoContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override IQueryable<Cotacao> GetAll()
        {
            return _contexto.Cotacao.Include(p => p.CotacaoItens).AsNoTracking();
        }
    }
}
