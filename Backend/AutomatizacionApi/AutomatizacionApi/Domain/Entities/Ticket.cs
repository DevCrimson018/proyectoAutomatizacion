﻿using AutomatizacionApi.Domain.Entities.Common;

namespace AutomatizacionApi.Domain.Entities
{
    public class Ticket : BaseEntity<int>
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }

        //Navigation Properties
        public Location? Location { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
