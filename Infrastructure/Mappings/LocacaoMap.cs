using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAuditoria.Api.Data.Mappings
{
    public class LocacaoMap : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            //Table name
            builder.ToTable("Locacao");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Id_Cliente)
                .IsRequired()
                .HasColumnName("Id_Cliente")
                .HasColumnType("int");

            builder.Property(x => x.Id_Cliente)
                .IsRequired()
                .HasColumnName("Id_Cliente")
                .HasColumnType("int");

            //Fk
            builder.HasOne(x => x.Cliente)
                .WithMany( x => x.Locacoes)
                .HasForeignKey(x => x.Id_Cliente)
                .HasConstraintName("FK_Cliente_idx")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Filme)
                .WithMany( x => x.Locacoes)
                .HasForeignKey(x => x.Id_Filme)
                .HasConstraintName("FK_Filme_idx")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}