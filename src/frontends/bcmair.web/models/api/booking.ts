import { BookingPassenger } from './bookingPassenger';

export interface Booking {
    createdByUserId: string;
    referenceNumber: string;
    flightNumber: string;
    passengers: BookingPassenger[];
}
