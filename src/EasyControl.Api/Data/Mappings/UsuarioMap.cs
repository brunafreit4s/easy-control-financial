using Microsoft.EntityFrameworkCore;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            // 2º - Configuração - Definir como o Entity deve criar a tabela na base de dados
            builder.ToTable("Usuario").HasKey(p => p.Id);
            builder.Property(p => p.Email).HasColumnType("VARCHAR").IsRequired();
            builder.Property(p => p.Password).HasColumnType("VARCHAR").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnName("DataCadastro").HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DataInativacao).HasColumnType("timestamp");
        }
    }
}