using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    // 10º CRUD - Criar Service base
    /// <summary>
    /// Interface generica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="RQ">Contrato de Request</typeparam>
    /// <typeparam name="RS">Contrato de Response</typeparam>
    /// <typeparam name="I">Identificador (ID)</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> GetAll(I idUsuario);
        Task<RS> GetById(I id, I idUsuario);
        Task<RS> Add(RQ entidade, I idUsuario);
        Task<RS> Update(I id, RQ entidade, I idUsuario);
        Task Delete(I id, I idUsuario);
    }
}