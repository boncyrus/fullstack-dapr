import axios from 'axios';
import { CreateBookingResponse } from '../models/api/commands/createBookingResponse';
import { CreateBookingRequest } from './../models/api/commands/createBookingRequest';
import { GetUserBookingsResponse } from './../models/api/queries/getUserBookingsResponse';

export class BookingsApi {
    private readonly hostUrl: string;

    constructor() {
        this.hostUrl = process.env.BOOKINGS_API_HOST ? process.env.BOOKINGS_API_HOST : '';
    }

    async getUserBookings(userId: string) {
        try {
            const apiResponse = await axios.get<GetUserBookingsResponse>(
                `${this.hostUrl}/api/bookings/users/${userId}`,
                {
                    headers: {
                        accept: 'application/json',
                    },
                }
            );

            return apiResponse.data;
        } catch (error) {
            console.error(error);
            return undefined;
        }
    }

    async creatBooking(request: CreateBookingRequest) {
        try {
            console.log(`${this.hostUrl}/api/bookings`);

            const apiResponse = await axios.post<CreateBookingResponse>(`${this.hostUrl}/api/bookings`, request, {
                headers: {
                    accept: 'application/json',
                    'content-type': 'application/json',
                },
            });

            return apiResponse.data;
        } catch (error) {
            console.error(error);
            return undefined;
        }
    }
}
