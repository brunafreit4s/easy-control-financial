using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyControl.Api.Contract.Usuario;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    // 10º CRUD - Criar Service da entidade
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, long>
    {
        Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequestContract);
    }
}