using EasyControl.Api.Data;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Domain.Repository.Classes
{
    // 2º - CRUD - Construir a classe Repository
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Injeção de Dependência
        private readonly ApplicationContext _contexto;

        public UsuarioRepository(ApplicationContext contexto){
            _contexto = contexto;
        }
        #endregion             

        public async Task<Usuario> Add(Usuario entidade)
        {
            await _contexto.Usuario.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            //return await GetById(entidade.Id);
            return entidade;
        }

        public async Task Delete(Usuario entidade)
        {
            // Delete físico
            _contexto.Entry(entidade).State = EntityState.Deleted;
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _contexto.Usuario.AsNoTracking().OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _contexto.Usuario.AsNoTracking()
                .Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> GetById(long id)
        {
            return await _contexto.Usuario.AsNoTracking()
                .Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Update(Usuario entidade)
        {
            Usuario entidadeBanco = await _contexto.Usuario.Where(u => u.Id == entidade.Id).FirstOrDefaultAsync();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Usuario>(entidadeBanco);

            return entidadeBanco;
        }
    }
}