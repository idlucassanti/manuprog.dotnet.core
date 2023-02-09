using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Core.Domain.Entities;

namespace MP.Core.Infra.Data.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.Documento)
                .HasColumnName("Documento");

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone");


            builder.HasMany(x => x.Compras)
                .WithOne(y => y.Pessoa)
                .HasForeignKey(y => y.PessoaId);
        }
    }
}
