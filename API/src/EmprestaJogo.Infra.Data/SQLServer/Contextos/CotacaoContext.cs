using Cotacoes.Domain.Entities;
using Cotacoes.Infra.Data.SQLServer.Map;
using Microsoft.EntityFrameworkCore;

namespace Cotacoes.Infra.Data.SQLServer.Contexts
{
    public class CotacaoContext : DbContext
    {
        public CotacaoContext(DbContextOptions<CotacaoContext> options) : base(options) { }

        public DbSet<Cotacao> Cotacao { get; set; }
        public DbSet<CotacaoItem> CotacaoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CotacaoMap());
            modelBuilder.ApplyConfiguration(new CotacaoItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
