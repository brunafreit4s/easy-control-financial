using EasyControl.Api.Contract.Usuario;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    // 10º CRUD - Criar Service da entidade
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, long>
    {
        Task<UsuarioLoginResponseContract> Authenticate(UsuarioLoginRequestContract usuarioLoginRequestContract);
        Task<UsuarioResponseContract> GetByEmail(string email);
    }
}