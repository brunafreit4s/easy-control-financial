
namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // 8º - CRUD - Construir a Interface base
    // Todos os outros repositórios devem utilizar essa interface como base
    // T: Tipo de Entidade
    // I: Tipo de Identificador (ID)
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(I id);
        Task<T> Add(T entidade);
        Task<T> Update(T entidade);
        Task Delete(T entidade);
    }
}