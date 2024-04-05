using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    public interface INaturezaDeLancamentoRepository : IRepository<NaturezaDeLancamento, long>
    {
        Task<IEnumerable<NaturezaDeLancamento>> GetByIdUsuario(long id, long IdUsuario);   
    }
}