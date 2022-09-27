import { Passenger } from './passenger';

export interface Booking {
    createdByUserId: string;
    referenceNumber: string;
    flightNumber: string;
    passengers: Passenger[];
    origin: string;
    destination: string;
    departure: string;
    arrival: string;
}
