import { BookingPassenger } from './../bookingPassenger';

export interface CreateBookingRequest {
    userId: string;
    flightNumber: string;
    passengers: BookingPassenger[];
}
