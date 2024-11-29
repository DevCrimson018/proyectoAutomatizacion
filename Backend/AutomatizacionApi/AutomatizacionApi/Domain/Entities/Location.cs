using AutomatizacionApi.Domain.Entities.Common;

namespace AutomatizacionApi.Domain.Entities
{
    public class Location : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? Provincia { get; set; }
        public string? Street { get; set; }
        public string? DirectionLine { get; set; }
        public string? PostalCode { get; set; }

        //Navigation Properties
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
