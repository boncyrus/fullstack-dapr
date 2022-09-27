import { Button, Grid } from '@mui/material';
import { useRouter } from 'next/router';
import { ReactElement, useEffect, useState } from 'react';
import BookingCardList from '../components/booking-card-list/bookingCardList';
import { adminUserId } from '../constants/appConstants';
import MainLayout from '../layouts/mainLayout';
import { Booking } from '../models/dtos/booking';
import { BookingsService } from '../services/bookingsService';
import type { NextPageWithLayout } from './_app';

const Home: NextPageWithLayout = () => {
    const [bookings, setBookings] = useState<Booking[]>([]);

    useEffect(() => {
        const loadData = async () => {
            const bookingsService = new BookingsService();
            const data = await bookingsService.getBookings(adminUserId);

            setBookings(data);
        };

        loadData();
    }, []);

    const router = useRouter();
    const handleBookAFlight = (e: React.MouseEvent<HTMLButtonElement>) => {
        router.push('book-a-flight');
    };

    return (
        <>
            <BookingCardList bookings={bookings} emptyMessage="You don't have any bookings." />

            <Grid mt={3} container justifyContent='center'>
                <Grid item>
                    <Button type='submit' onClick={handleBookAFlight} variant='contained'>
                        Book a flight
                    </Button>
                </Grid>
            </Grid>
        </>
    );
};

Home.getLayout = (page: ReactElement) => {
    return <MainLayout title='My Bookings'>{page}</MainLayout>;
};

export default Home;
