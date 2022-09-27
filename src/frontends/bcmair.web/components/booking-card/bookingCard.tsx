import { Divider, Grid, Paper, Typography } from '@mui/material';
import { styled } from '@mui/material/styles';
import PlaneIcon from '@mui/icons-material/Flight';
import { Booking } from '../../models/dtos/booking';
import React from 'react';

interface BookingCardProps {
    booking: Booking;
}

const Path = styled(Typography)(
    ({ theme }) => `
    color: ${theme.palette.primary.main};
  `
);

const RightContainer = styled('div')`
    text-align: right;
`;

const CenterContainer = styled('div')`
    text-align: center;
`;

const Root = styled(Paper)(
    ({ theme }) => `
    padding: ${theme.spacing(3)}
  `
);

const PlaneIconRotated = styled(PlaneIcon)(
    ({ theme }) => `
    transform: rotate(90deg);
    color: ${theme.palette.primary.main};
    `
);

const FieldLabel = styled(Typography)(
    ({ theme }) => `
    color: ${theme.palette.primary.main};
  `
);

const BookingCard: React.FC<BookingCardProps> = ({ booking }) => {
    return (
        <>
            {
                <Root elevation={3}>
                    <Grid container>
                        <Grid item xs={12}>
                            <div>
                                <FieldLabel variant='caption'>Reference Number</FieldLabel>
                                <Typography variant='body1'>{booking.referenceNumber}</Typography>
                            </div>
                        </Grid>
                        <Grid item xs={4}>
                            <div>
                                <FieldLabel variant='caption'>Flight Number</FieldLabel>
                                <Typography variant='body1'>{booking.flightNumber}</Typography>
                            </div>
                        </Grid>
                        <Grid item xs={4}>
                            <CenterContainer>
                                <FieldLabel variant='caption'>Departure</FieldLabel>
                                <Typography variant='body1'>
                                    {new Date(booking.departure).toLocaleDateString()}
                                </Typography>
                            </CenterContainer>
                        </Grid>
                        <Grid item xs={4}>
                            <RightContainer>
                                <FieldLabel variant='caption'>Arrival</FieldLabel>
                                <Typography variant='body1'>
                                    {new Date(booking.arrival).toLocaleDateString()}
                                </Typography>
                            </RightContainer>
                        </Grid>
                    </Grid>

                    <Divider />

                    {/* Passengers Section */}
                    <Grid container alignItems='center'>
                        <Grid container item>
                            <Grid item xs={6}>
                                <FieldLabel variant='caption'>Passengers</FieldLabel>
                            </Grid>
                            <Grid item xs={6}>
                                <RightContainer>
                                    <FieldLabel variant='caption'>Seat</FieldLabel>
                                </RightContainer>
                            </Grid>
                        </Grid>
                        <Grid container item>
                            {booking.passengers.map((p, index) => (
                                <React.Fragment key={index}>
                                    <Grid item xs={6}>
                                        <Typography variant='body1'>{`${p.firstName} ${p.lastName}`}</Typography>
                                    </Grid>
                                    <Grid item xs={6}>
                                        <RightContainer>
                                            <Typography variant='body1'>{p.seatNumber}</Typography>
                                        </RightContainer>
                                    </Grid>
                                </React.Fragment>
                            ))}
                        </Grid>
                    </Grid>

                    <Grid mt={1} container xs={12} justifyContent='space-between' alignItems='center'>
                        <Grid xs={4} item>
                            <Path variant='body1'>{booking.origin}</Path>
                        </Grid>
                        <Grid xs={4} item>
                            <CenterContainer>
                                <PlaneIconRotated fontSize='large' />
                            </CenterContainer>
                        </Grid>
                        <Grid xs={4} item>
                            <RightContainer>
                                <Path variant='body1'>{booking.destination}</Path>
                            </RightContainer>
                        </Grid>
                    </Grid>
                </Root>
            }
        </>
    );
};

export default BookingCard;
