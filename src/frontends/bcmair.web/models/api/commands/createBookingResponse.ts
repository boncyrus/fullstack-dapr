import { BookingPassenger } from './../bookingPassenger';

export interface CreateBookingResponse {
    userId: string;
    flightNumber: string;
    passengers: BookingPassenger;
}
