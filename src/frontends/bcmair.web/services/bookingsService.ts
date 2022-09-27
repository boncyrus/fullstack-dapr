import { CreateBookingRequest } from '../models/api/commands/createBookingRequest';
import { Booking as BookingDto } from '../models/dtos/booking';
import { Passenger } from '../models/dtos/passenger';
import { Booking } from './../models/api/booking';
import { BookingPassenger } from './../models/api/bookingPassenger';
import { BookingsApi } from './bookingsApi';
import { FlightsService } from './flightsService';

export class BookingsService {
    private readonly bookingsApi: BookingsApi;
    private readonly flightsService: FlightsService;

    constructor() {
        this.bookingsApi = new BookingsApi();
        this.flightsService = new FlightsService();
    }

    async getBookings(userId: string) {
        const apiResponse = await this.bookingsApi.getUserBookings(userId);

        if (!apiResponse) {
            return [];
        }

        const bookings = await Promise.all(apiResponse.bookings.map(this.bookingMapper, this));
        const response: BookingDto[] = bookings.filter((x) => !!x) as BookingDto[];
        return response;
    }

    async createBooking(userId: string, flightNumber: string, passengers: Passenger[]) {
        try {
            const apiResponse = await this.bookingsApi.creatBooking(
                this.createBookingMapper(userId, flightNumber, passengers)
            );
            return apiResponse;
        } catch (error) {
            console.error(error);
        }
    }

    createBookingMapper(userId: string, flightNumber: string, passengers: Passenger[]): CreateBookingRequest {
        return {
            flightNumber: flightNumber,
            passengers: passengers.map(this.createBookingPassengerMapper),
            userId: userId,
        };
    }

    createBookingPassengerMapper(passenger: Passenger) {
        const result: BookingPassenger = {
            name: {
                first: passenger.firstName,
                last: passenger.lastName,
                middleInitial: passenger.middleInitial,
            },
            seatNumber: passenger.seatNumber,
        };

        return result;
    }

    async bookingMapper(booking: Booking) {
        var flight = await this.flightsService.getFlight(booking.flightNumber);

        if (!flight) {
            return undefined;
        }

        const result: BookingDto = {
            createdByUserId: booking.createdByUserId,
            flightNumber: booking.flightNumber,
            passengers: booking.passengers.map(this.passengerMapper, this),
            referenceNumber: booking.referenceNumber,
            arrival: flight.arrival,
            departure: flight.departure,
            origin: flight.origin,
            destination: flight.destination,
        };

        return result;
    }

    passengerMapper(passenger: BookingPassenger) {
        const result: Passenger = {
            firstName: passenger.name.first,
            lastName: passenger.name.last,
            middleInitial: passenger.name.middleInitial,
            seatNumber: passenger.seatNumber,
        };

        return result;
    }
}
