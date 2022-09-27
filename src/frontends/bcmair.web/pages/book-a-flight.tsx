import { useRouter } from 'next/router';
import { ReactElement, useEffect, useState } from 'react';
import BookAFlightForm from '../components/book-a-flight-form/bookAFlightForm';
import { adminUserId } from '../constants/appConstants';
import MainLayout from '../layouts/mainLayout';
import { Flight } from '../models/dtos/flight';
import { Passenger } from '../models/dtos/passenger';
import { BookingsService } from '../services/bookingsService';
import { FlightsService } from '../services/flightsService';
import { NextPageWithLayout } from './_app';

const BookAFlight: NextPageWithLayout = () => {
    const [flights, setFlights] = useState<Flight[]>([]);
    const router = useRouter();

    const handleOnSubmit = async (data: { flight: Flight; form: { passengers: Passenger[] } }) => {
        const bookingsService = new BookingsService();
        await bookingsService.createBooking(adminUserId, data.flight.flightNumber, data.form.passengers);
        router.replace('/');
    };

    useEffect(() => {
        const loadData = async () => {
            const flightsService = new FlightsService();
            const data = await flightsService.getFlights();

            setFlights(data);
        };

        loadData();
    }, []);

    return (
        <>
            <BookAFlightForm onSubmit={handleOnSubmit} flights={flights} />
        </>
    );
};

BookAFlight.getLayout = (page: ReactElement) => {
    return <MainLayout title='Book a flight'>{page}</MainLayout>;
};

export default BookAFlight;
