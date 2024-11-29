using AutomatizacionApi.Domain.Entities.Common;
using AutomatizacionApi.Domain.Entities.User;

namespace AutomatizacionApi.Domain.Entities
{
    public class Bus : BaseEntity<Guid>
    {
        public string? CodeBus { get; set; }
        public string? Plate { get; set; }
        public int StatusId { get; set; }
        public BusStatus? Status { get; set; }
        public string? DriverId { get; set; }
        public Driver? Driver { get; set; }

    }
}
