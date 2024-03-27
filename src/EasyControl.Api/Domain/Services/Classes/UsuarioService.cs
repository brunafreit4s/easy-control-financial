using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        #region Injeção de Dependência
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }
        #endregion

        public Task<UsuarioResponseContract> Add(UsuarioRequestContract entidade, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequestContract)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioResponseContract>> GetAll(long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponseContract> GetById(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponseContract> Update(long id, UsuarioRequestContract entidade, long idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}