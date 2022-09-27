import { Grid, Typography } from '@mui/material';
import { Booking } from '../../models/dtos/booking';
import BookingCard from '../booking-card/bookingCard';

interface BookingCardListProps {
    bookings: Booking[];
    emptyMessage?: string;
}

const BookingCardList: React.FC<BookingCardListProps> = (props) => {
    return (
        <>
            {props.bookings?.length > 0 ? (
                <Grid spacing={2}>
                    {props.bookings.map((booking) => (
                        <Grid p={2} item key={booking.referenceNumber} xs={12} md={6}>
                            <BookingCard booking={booking}></BookingCard>
                        </Grid>
                    ))}
                </Grid>
            ) : (
                <Typography textAlign='center'>{props?.emptyMessage || 'List is empty.'}</Typography>
            )}
        </>
    );
};

export default BookingCardList;
