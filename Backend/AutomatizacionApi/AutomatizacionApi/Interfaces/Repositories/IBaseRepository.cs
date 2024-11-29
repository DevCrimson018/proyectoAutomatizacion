using AutomatizacionApi.Entities.Common;

namespace AutomatizacionApi.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Delete(Tkey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(Tkey id);
        Task<TEntity> Update(TEntity entity);
    }
}