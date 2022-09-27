import { Grid, Typography, styled } from '@mui/material';
import { Flight } from '../../models/dtos/flight';
import FlightCard from '../flight-card/flightCard';

interface FlightCardListProps {
    flights: Flight[];
    emptyMessage?: string;
    onCardClick?: (flight: Flight) => void;
}

const SelectableGrid = styled(Grid)`
    &:hover {
        cursor: pointer;
        transform: scale(1.02);
        transition: all 0.2s ease-in-out;
    }
`;

const FlightCardList: React.FC<FlightCardListProps> = (props) => {
    return (
        <>
            {props.flights?.length > 0 ? (
                <Grid container>
                    {props.flights.map((flight) => (
                        <SelectableGrid
                            onClick={() => props?.onCardClick && props.onCardClick(flight)}
                            p={2}
                            item
                            key={flight.id}
                            xs={12}
                        >
                            <FlightCard flight={flight}></FlightCard>
                        </SelectableGrid>
                    ))}
                </Grid>
            ) : (
                <Typography textAlign='center'>{props?.emptyMessage || 'List is empty.'}</Typography>
            )}
        </>
    );
};

export default FlightCardList;
