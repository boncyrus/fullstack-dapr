using AutoMapper;
using Bcm.BcmAir.Booking.Api.Events;
using Bcm.BcmAir.Booking.Api.Helpers;
using Bcm.BcmAir.Booking.Api.Infrastructure;
using Bcm.BcmAir.Booking.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Booking.Api.Models;
using Bcm.BcmAir.Booking.Api.Models.Domain;
using Bcm.BcmAir.Infrastructure.Common.Constants;
using Bcm.BcmAir.Infrastructure.Common.Messaging;
using Dapr.Client;
using MediatR;

namespace Bcm.BcmAir.Booking.Api.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        private readonly DaprClient _dapr;
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMapper _mapper;
        private readonly IServiceBus _serviceBus;
        private readonly ILogger<CreateBookingCommandHandler> _logger;

        public CreateBookingCommandHandler(
            DaprClient dapr,
            IBookingsRepository bookingsRepository,
            IMapper mapper,
            IServiceBus serviceBus,
            ILogger<CreateBookingCommandHandler> logger)
        {
            _dapr = dapr;
            _bookingsRepository = bookingsRepository;
            _mapper = mapper;
            _serviceBus = serviceBus;
            _logger = logger;
        }

        public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var invocationClient = DaprClient.CreateInvokeHttpClient();

            try
            {
                var availabilityHttpResponse = await invocationClient
                    .GetAsync($"http://catalog/api/flights/{request.FlightNumber}/availability");

                availabilityHttpResponse.EnsureSuccessStatusCode();

                var isFlightAvailable = bool.Parse(await availabilityHttpResponse.Content.ReadAsStringAsync());

                if (!isFlightAvailable)
                {
                    return null;
                }

                var booking = new Models.Domain.Booking
                {
                    FlightNumber = request.FlightNumber.ToUpper(),
                    Passengers = _mapper.Map<IList<BookingPassengerDetail>>(request.Passengers),
                    ReferenceNumber = BookingReferenceNumberHelper.GenerateBookingReferenceNumber(),
                    CreatedByUserId = request.UserId
                };

                await _bookingsRepository.CreateBooking(booking);

                await _serviceBus.Publish(new BookingCreatedEvent(booking.FlightNumber, booking.Passengers.Count));

                return _mapper.Map<BookingDto>(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to create booking");
                return null;
            }
        }
    }
}
