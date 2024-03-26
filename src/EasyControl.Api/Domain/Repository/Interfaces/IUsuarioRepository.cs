using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // 2º - CRUD - Construir o Repository
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario?> GetByEmail(string email);
    }
}