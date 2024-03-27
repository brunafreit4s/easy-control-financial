using EasyControl.Api.Data.Mappings;
using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Data
{
    public class ApplicationContext : DbContext
    {
        // 3º - Configuração - Criação do Construtor - Serve para definir como o Entity deve controlar as entidades
        public DbSet<Usuario> Usuario { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //base.OnModelCreating(modelBuilder);
        }
    }
}