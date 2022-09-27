import { Divider, Grid, Paper, Typography } from '@mui/material';
import { Flight } from '../../models/dtos/flight';
import { styled } from '@mui/material/styles';
import FlightIcon from '@mui/icons-material/Flight';

interface FlightCardProps {
    flight: Flight;
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

const FieldLabel = styled(Typography)(
    ({ theme }) => `
    color: ${theme.palette.primary.main};
  `
);

const PlaneIconRotated = styled(FlightIcon)(
    ({ theme }) => `
    transform: rotate(90deg);
    color: ${theme.palette.primary.main};
    `
);

const FlightCard: React.FC<FlightCardProps> = ({ flight }) => {
    return (
        <>
            {
                <Root elevation={3}>
                    <Grid container alignItems='center'>
                        <Grid item xs={4}>
                            <div>
                                <FieldLabel variant='caption'>Flight</FieldLabel>
                                <Typography variant='body1'>{flight.flightNumber}</Typography>
                            </div>
                        </Grid>
                        <Grid item xs={4}>
                            <CenterContainer>
                                <FieldLabel variant='caption'>Departure</FieldLabel>
                                <Typography variant='body1'>
                                    {new Date(flight.departure).toLocaleDateString()}
                                </Typography>
                            </CenterContainer>
                        </Grid>
                        <Grid item xs={4}>
                            <RightContainer>
                                <FieldLabel variant='caption'>Arrival</FieldLabel>
                                <Typography variant='body1'>{new Date(flight.arrival).toLocaleDateString()}</Typography>
                            </RightContainer>
                        </Grid>
                    </Grid>

                    <Divider />

                    <Grid mt={1} container justifyContent='space-between' alignItems='center'>
                        <Grid xs={4} item>
                            <Path variant='body1'>{flight.origin}</Path>
                        </Grid>
                        <Grid xs={4} item>
                            <CenterContainer>
                                <PlaneIconRotated fontSize='large' />
                            </CenterContainer>
                        </Grid>
                        <Grid xs={4} item>
                            <RightContainer>
                                <Path variant='body1'>{flight.destination}</Path>
                            </RightContainer>
                        </Grid>
                    </Grid>
                </Root>
            }
        </>
    );
};

export default FlightCard;
