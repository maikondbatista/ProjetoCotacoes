using Cotacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cotacoes.Infra.Data.SQLServer.Map
{
    public class CotacaoItemMap : IEntityTypeConfiguration<CotacaoItem>
    {
        public void Configure(EntityTypeBuilder<CotacaoItem> builder)
        {
            builder.ToTable("CotacaoItem");

            builder
                .HasKey(p => p.NumeroItem);

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(p => p.NumeroItem)
                 .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(p => p.NumeroCotacao)
                .IsRequired();

            builder
                .Property(p => p.Preco);

            builder
                .Property(p => p.Quantidade)
                .IsRequired();

            builder
                .Property(p => p.Marca)
                .HasMaxLength(50);

            builder
                .Property(p => p.Unidade)
                .HasMaxLength(30);
        }
    }
}
