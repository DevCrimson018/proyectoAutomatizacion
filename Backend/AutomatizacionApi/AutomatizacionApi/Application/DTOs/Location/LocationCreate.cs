namespace AutomatizacionApi.Application.DTOs.Location
{
    public class LocationCreate
    {
        public string? Name { get; set; }
        public string? Provincia { get; set; }
        public string? Street { get; set; }
        public string? DirectionLine { get; set; }
        public string? PostalCode { get; set; }
    }
}
