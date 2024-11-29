
namespace AutomatizacionApi.Entities.Common
{
    public class BaseEntity<T> : IAuditable
    {
        public T? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
