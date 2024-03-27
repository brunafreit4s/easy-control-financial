using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // 8º - CRUD - Construir a Interface da entidade
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario?> GetByEmail(string email);
    }
}