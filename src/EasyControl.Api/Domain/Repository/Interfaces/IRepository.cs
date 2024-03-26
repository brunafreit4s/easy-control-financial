
namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // T: Tipo de Entidade
    // I: Tipo de Identificador (ID)
    // 2º - CRUD - Construir o Repository
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(I id);
        Task<T> Add(T entidade);
        Task<T> Update(T entidade);
        Task Delete(T entidade);
    }
}