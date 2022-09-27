using AutoMapper;
using Bcm.BcmAir.Booking.Api.Models;

namespace Bcm.BcmAir.Booking.Api.Mappings
{
    public class BookingsMappingProfile : Profile
    {
        public BookingsMappingProfile()
        {
            CreateMap<Models.Domain.Booking, BookingDto>();
            CreateMap<Models.Domain.BookingPassengerDetail, BookingPassengerDetailDto>();
            CreateMap<BookingPassengerDetailDto, Models.Domain.BookingPassengerDetail>();
        }
    }
}
