import { DateRange } from '../dateRange';

export interface GetFlightsQueryRequest {
    range?: DateRange;
    flightNumber?: string;
}
