using AutomatizacionApi.Entities;

namespace AutomatizacionApi.Repositories
{
    public class BaseRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
    {

    }
}
