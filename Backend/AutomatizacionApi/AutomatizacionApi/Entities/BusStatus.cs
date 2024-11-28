﻿using AutomatizacionApi.Entities.Common;

namespace AutomatizacionApi.Entities
{
    public class BusStatus : BaseEntity<int>
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
    }
}