import { FlightNumber } from '../models/api/flightNumber';

export const ParseFlightNumber = (flightNumber: FlightNumber) => {
    return `${flightNumber.iataCode}${flightNumber.identifier}`;
};
