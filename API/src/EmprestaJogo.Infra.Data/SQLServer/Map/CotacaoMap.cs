using Cotacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cotacoes.Infra.Data.SQLServer.Map
{
    public class CotacaoMap : IEntityTypeConfiguration<Cotacao>
    {
        public void Configure(EntityTypeBuilder<Cotacao> builder)
        {
            builder.ToTable("Cotacao");

            builder
                .HasKey(e => e.NumeroCotacao);

            builder
                .Property(p => p.CNPJComprador)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(p => p.CNPJFornecedor)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(p => p.NumeroCotacao)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(p => p.DataCotacao)
                .IsRequired();

            builder
                .Property(p => p.DataEntregaCotacao)
                .IsRequired();

            builder
                .Property(p => p.CEP)
                .HasMaxLength(9)
                .IsRequired();

            builder
                .Property(p => p.Logradouro)
                .HasMaxLength(200);

            builder
                .Property(p => p.Complemento)
                .HasMaxLength(50);

            builder.Property(p => p.Bairro)
                .HasMaxLength(80);

            builder.Property(p => p.UF)
                .HasMaxLength(2);

            builder.Property(p => p.Observacao)
                .HasMaxLength(200);

            builder
                .HasMany(p => p.CotacaoItens)
                .WithOne(p => p.Cotacao)
                .HasForeignKey(p => p.NumeroCotacao);
        }
    }
}
