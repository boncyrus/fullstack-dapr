import axios from 'axios';
import { GetFlightQueryResponse } from '../models/api/queries/getFlightQueryResponse';
import { GetFlightsQueryResponse } from '../models/api/queries/getFlightsQueryResponse';
import { GetFlightsQueryRequest } from './../models/api/queries/getFlightsQueryRequest';

export class FlightsApi {
    private readonly hostUrl: string;

    constructor() {
        this.hostUrl = process.env.CATALOG_API_HOST ? process.env.CATALOG_API_HOST : '';
        // this.hostUrl = 'http://localhost:8080';
    }

    async getFlights(request: GetFlightsQueryRequest) {
        try {
            const apiResponse = await axios.post<GetFlightsQueryResponse>(`${this.hostUrl}/api/flights`, request, {
                headers: {
                    'content-type': 'application/json',
                    accept: 'application/json',
                },
            });

            return apiResponse.data;
        } catch (error) {
            console.error(error);
            return undefined;
        }
    }

    async getFight(flightNumber: string) {
        try {
            const apiResponse = await axios.get<GetFlightQueryResponse>(`${this.hostUrl}/api/flights/${flightNumber}`, {
                headers: {
                    'content-type': 'application/json',
                    accept: 'application/json',
                },
            });

            return apiResponse.data;
        } catch (error) {
            console.error(error);
            return undefined;
        }
    }
}
