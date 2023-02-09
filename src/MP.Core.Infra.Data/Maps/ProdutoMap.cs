using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Core.Domain.Entities;

namespace MP.Core.Infra.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.Codigo)
                .HasColumnName("Codigo");

            builder.Property(x => x.Preco)
                .HasColumnName("Preco");

            builder.HasMany(x => x.Compras)
                .WithOne(y => y.Produto)
                .HasForeignKey(y => y.ProdutoId);
        }
    }
}
