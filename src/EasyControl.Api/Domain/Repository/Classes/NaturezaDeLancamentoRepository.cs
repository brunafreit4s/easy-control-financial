using EasyControl.Api.Data;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Domain.Repository.Classes
{
    public class NaturezaDeLancamentoRepository : INaturezaDeLancamentoRepository
    {
        private readonly ApplicationContext _context;
        public NaturezaDeLancamentoRepository(ApplicationContext context){
            _context = context;
        }

        public async Task<NaturezaDeLancamento> Add(NaturezaDeLancamento entidade)
        {
            await _context.NaturezaDeLancamento.AddAsync(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Delete(NaturezaDeLancamento entidade)
        {
            // _context.Entry(entidade).State = EntityState.Deleted;
            // await _context.SaveChangesAsync();

            // Deleção lógica, apenas atualizando a data de inativação
            entidade.DataInativacao = DateTime.Now;
            await Update(entidade);
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> GetAll()
        {
            return await _context.NaturezaDeLancamento
                .AsNoTracking()
                .OrderBy(n => n.Id)
                .ToListAsync();
        }

        public async Task<NaturezaDeLancamento?> GetById(long id)
        {
            return await _context.NaturezaDeLancamento
                .AsNoTracking()
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> GetByIdUsuario(long IdUsuario)
        {
            return await _context.NaturezaDeLancamento.AsNoTracking()
                .Where(n => n.IdUsuario == IdUsuario)
                .OrderBy(n => n.Id)
                .ToListAsync();
        }

        public async Task<NaturezaDeLancamento> Update(NaturezaDeLancamento entidade)
        {
            NaturezaDeLancamento entidadeBanco = await _context.NaturezaDeLancamento.Where(n => n.Id == entidade.Id).FirstOrDefaultAsync();

            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<NaturezaDeLancamento>(entidadeBanco);
            
            return entidadeBanco;
        }
    }
}