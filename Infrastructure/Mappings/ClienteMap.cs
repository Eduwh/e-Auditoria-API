using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAuditoria.Api.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Table name
            builder.ToTable("Cliente");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime2")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            //Index

            builder.HasIndex(x => x.CPF).IsUnique();
            builder.HasIndex(x => x.Nome);            
        }
    }
}
