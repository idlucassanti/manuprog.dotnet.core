using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Core.Domain.Entities;

namespace MP.Core.Infra.Data.Maps
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(x => x.PessoaId)
                .HasColumnName("PessoaId");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("ProdutoId");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro");

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.Compras);

            builder.HasOne(x => x.Produto)
                .WithMany(p => p.Compras);
        }
    }
}
