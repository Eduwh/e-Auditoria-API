using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAuditoria.Api.Data.Mappings
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            //Table name
            builder.ToTable("Filme");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ClassificacaoIndicativa)
                .IsRequired()
                .HasColumnName("ClassificacaoIndicativa")
                .HasColumnType("int");

            builder.Property(x => x.Lancamento)
                .IsRequired()
                .HasColumnName("Lancamento")
                .HasColumnType("tinyint");

            //Indexes
            
            builder.HasIndex(x => x.ClassificacaoIndicativa);
        }
    }
}
