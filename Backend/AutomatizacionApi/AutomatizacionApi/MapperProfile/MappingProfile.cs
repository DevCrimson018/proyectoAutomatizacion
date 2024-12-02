using AutoMapper;
using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Application.DTOs.Location;
using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Application.DTOs.Ticket;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Domain.Entities.User;

namespace AutomatizacionApi.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerCreate>().ReverseMap();
            CreateMap<Driver, DriverCreate>().ReverseMap();
            CreateMap<Admin, AdminCreate>().ReverseMap();
            CreateMap<Ticket, TicketCreateDTo>().ReverseMap();
            CreateMap<Location, LocationCreate>().ReverseMap();
            CreateMap<Reservation, ReservationCreate>().ReverseMap();

        }
    }
}
