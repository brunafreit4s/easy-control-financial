using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Azure.Identity;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        #region Construtor e Injeção de Dependência
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, TokenService tokenService){
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        #endregion

        public async Task<UsuarioResponseContract> Add(UsuarioRequestContract entidade, long idUsuario)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Password = GenerateHashPassword(usuario.Password);
            usuario.DataCadastro = DateTime.Now;
            usuario = await _usuarioRepository.Add(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<UsuarioLoginResponseContract> Authenticate(UsuarioLoginRequestContract usuarioLoginRequestContract)
        {
            var usuario = await GetByEmail(usuarioLoginRequestContract.Email);
            var hashPassword = GenerateHashPassword(usuarioLoginRequestContract.Password);

            if(usuario is null || usuario.Password != hashPassword)
            {
                throw new AuthenticationException("Usuário ou Senha inválida!");
            }

            return new UsuarioLoginResponseContract{
                Id = usuario.Id,
                Email = usuario.Email,
                Token = _tokenService.GenerateToken(_mapper.Map<Usuario>(usuario))
            };
        }

        public async Task Delete(long id, long idUsuario)
        {
            UsuarioResponseContract usuario = await GetById(id) ?? throw new Exception("Usuário não encontrado para inativação!");
            await _usuarioRepository.Delete(_mapper.Map<Usuario>(usuario));
        }

        public async Task<IEnumerable<UsuarioResponseContract>> GetAll()
        {
            //Verificar como será feito com idUsuario (não entendi até o momento)
            var usuario = await _usuarioRepository.GetAll();
            //return _mapper.Map<IEnumerable<UsuarioResponseContract>>(usuario);
            return usuario.Select(usuario => _mapper.Map<UsuarioResponseContract>(usuario));
        }

        public async Task<UsuarioResponseContract> GetByEmail(string email)
        {
            var usuario = await _usuarioRepository.GetByEmail(email);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<UsuarioResponseContract> GetById(long id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<UsuarioResponseContract> Update(long id, UsuarioRequestContract entidade, long idUsuario)
        {
            _ = await GetById(id) ?? throw new Exception("Usuário não encontrado para atualização!");

            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Id = id;
            usuario.Password = GenerateHashPassword(entidade.Password);         
            usuario = await _usuarioRepository.Update(usuario);                        
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        private string GenerateHashPassword(string password)
        {
            string hashPassword;
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] bytesHash = sha256.ComputeHash(bytes);
                hashPassword = BitConverter.ToString(bytesHash).Replace("-", "").Replace("-", "").ToLower();
            }
            return hashPassword;
        }
    }
}