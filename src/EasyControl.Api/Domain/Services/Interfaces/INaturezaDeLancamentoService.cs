using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyControl.Api.Contract.NaturezaLancamento;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    public interface INaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    {
        Task<NaturezaDeLancamentoResponseContract> GetByIdUsuario(long id, long idUsuario);
    }
}