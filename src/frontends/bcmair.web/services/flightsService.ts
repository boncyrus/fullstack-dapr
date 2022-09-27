import { ParseFlightNumber } from '../helpers/flightNumberHelper';
import { Flight as FlightDto } from '../models/api/flight';
import { Flight } from '../models/dtos/flight';
import { DateRange } from './../models/api/dateRange';
import { FlightsApi } from './flightsApi';

export class FlightsService {
    private readonly flightsApi: FlightsApi;

    constructor() {
        this.flightsApi = new FlightsApi();
    }

    public async getFlights(range: DateRange | undefined = undefined, flightNumber: string = '') {
        const data = await this.flightsApi.getFlights({
            range: range || undefined,
            flightNumber: flightNumber || undefined,
        });

        if (!data) {
            return [];
        }

        const result = data.flights.map(this.flightMapper);
        return result;
    }

    public async getFlight(flightNumber: string) {
        const data = await this.flightsApi.getFight(flightNumber);

        if (!data) {
            return undefined;
        }

        const result = this.flightMapper(data);
        return result;
    }

    private flightMapper(flight: FlightDto) {
        const result: Flight = {
            arrival: flight.schedule.start,
            departure: flight.schedule.end,
            destination: flight.path.destination,
            origin: flight.path.origin,
            id: flight.id,
            flightNumber: ParseFlightNumber(flight.flightNumber),
        };

        return result;
    }
}
