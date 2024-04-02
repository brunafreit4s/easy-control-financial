using Microsoft.EntityFrameworkCore;
using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyControl.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // 2º - Configuração - Criação do Map - Serve para definir como o Entity deve criar a tabela na base de dados
            builder.ToTable("Usuario").HasKey(p => p.Id);
            builder.Property(p => p.Email).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("VARCHAR(MAX)").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DataInativacao).HasColumnName("DataInativacao").HasColumnType("DATETIME");
        }
    }
}