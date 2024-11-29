using AutomatizacionApi.Entities.Common;

namespace AutomatizacionApi.Repositories
{
    public class BaseRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
    {

    }
}
