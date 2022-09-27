import { FlightNumber } from './flightNumber';
import { TravelSchedule } from './travelSchedule';
import { TravelPath } from './travelPath';

export interface Flight {
    id: string;
    path: TravelPath;
    schedule: TravelSchedule;
    flightNumber: FlightNumber;
}
