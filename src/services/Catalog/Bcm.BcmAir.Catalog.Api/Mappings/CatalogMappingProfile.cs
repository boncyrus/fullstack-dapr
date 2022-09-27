using AutoMapper;
using Bcm.BcmAir.Catalog.Api.Events;
using Bcm.BcmAir.Catalog.Api.Flights.Commands.SellFlight;
using Bcm.BcmAir.Catalog.Api.Models;
using Bcm.BcmAir.Catalog.Api.Models.Domain;

namespace Bcm.BcmAir.Catalog.Api.Mappings
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<Flight, TravelPath>()
                .ForMember(cfg => cfg.Destination, src => src.MapFrom(m => m.Destination))
                .ForMember(cfg => cfg.Origin, src => src.MapFrom(m => m.Origin));

            CreateMap<Flight, FlightNumber>()
                .ForMember(cfg => cfg.Identifier, src => src.MapFrom(m => m.Identifier))
                .ForMember(cfg => cfg.IataCode, src => src.MapFrom(m => m.IataCode));

            CreateMap<Flight, TravelSchedule>()
                .ForMember(cfg => cfg.Start, src => src.MapFrom(m => m.Departure))
                .ForMember(cfg => cfg.End, src => src.MapFrom(m => m.Arrival));

            CreateMap<Flight, FlightDto>()
                .ForMember(cfg => cfg.Path, src => src.MapFrom(m => m))
                .ForMember(cfg => cfg.FlightNumber, src => src.MapFrom(m => m))
                .ForMember(cfg => cfg.Schedule, src => src.MapFrom(m => m));

            CreateMap<SellFlightEvent, SellFlightCommand>();
        }
    }
}
