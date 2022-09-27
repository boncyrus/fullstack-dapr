import AddIcon from '@mui/icons-material/Add';
import BackIcon from '@mui/icons-material/ArrowBack';
import DeleteIcon from '@mui/icons-material/Delete';
import {
    Button,
    Divider,
    Grid,
    IconButton,
    Step,
    StepLabel,
    Stepper,
    styled,
    Tooltip,
    Typography,
} from '@mui/material';
import { FieldArray, Form, Formik, FormikHelpers } from 'formik';
import { useState } from 'react';
import { Flight } from '../../models/dtos/flight';
import { Passenger } from '../../models/dtos/passenger';
import { SeatsService } from '../../services/seatsService';
import { BcmInput } from '../core/bcm-input/bcmInput';
import FlightCardList from '../flight-card-list/flight-card-list';

interface FormValues {
    passengers: Passenger[];
}

const seatsService = new SeatsService();

const getDefaultPassenger = (): Passenger => {
    return {
        firstName: '',
        lastName: '',
        middleInitial: '',
        seatNumber: seatsService.generateSeatNumber(),
    };
};

const PassengerFieldsContainer = styled('div')(
    ({ theme }) => `
    padding: ${theme.spacing(2)} 0;
  `
);

const steps = [
    {
        label: 'Select flight',
    },
    {
        label: 'Add passenger',
    },
];

interface BookAFlightFormProps {
    flights: Flight[];
    onSubmit: (data: { flight: Flight; form: FormValues }) => void;
}

const BookAFlightForm: React.FC<BookAFlightFormProps> = ({ flights, onSubmit }) => {
    const [currentStep, setCurrentStep] = useState(0);
    const [selectedFlight, setSelectedFlight] = useState<Flight>();

    const initialValues: FormValues = {
        passengers: [getDefaultPassenger()],
    };

    const onFormSubmit = (values: FormValues, helpers: FormikHelpers<FormValues>) => {
        if (!selectedFlight) {
            return;
        }

        onSubmit({
            flight: selectedFlight,
            form: values,
        });
    };

    const handleSelectFlight = (flight: Flight) => {
        setSelectedFlight(flight);
    };

    const handleProceedFromSelectFlight = () => {
        if (!selectedFlight) {
            return;
        }

        nextStep();
    };

    const nextStep = () => {
        setCurrentStep((prevStep) => prevStep + 1);
    };

    const previousStep = () => {
        setCurrentStep((prevStep) => prevStep - 1);
    };

    const currentContent = (step: number) => {
        if (step === 0) {
            return (
                <>
                    <Typography>
                        {selectedFlight ? `Selected flight: ${selectedFlight.flightNumber}` : 'Please select a flight'}
                    </Typography>
                    <FlightCardList
                        onCardClick={handleSelectFlight}
                        flights={flights}
                        emptyMessage='No flights found'
                    />
                    <Grid container justifyContent='center'>
                        <Grid item justifySelf='center'>
                            <Button
                                onClick={handleProceedFromSelectFlight}
                                type='button'
                                variant='contained'
                                disabled={!selectedFlight}
                            >
                                Proceed
                            </Button>
                        </Grid>
                    </Grid>
                </>
            );
        } else if (step == 1) {
            return AddPassengerForm;
        }
    };

    const AddPassengerForm = (
        <Formik initialValues={initialValues} onSubmit={onFormSubmit}>
            {({ values }) => {
                return (
                    <>
                        {/* <pre>{JSON.stringify(values, null, 2)}</pre> */}
                        <Form>
                            <Grid container>
                                <Grid item xs={12}>
                                    <FieldArray name='passengers'>
                                        {({ push, remove }) => {
                                            const handleAddPax = () => {
                                                push(getDefaultPassenger());
                                            };

                                            const handleRemovePax = (index: number) => {
                                                remove(index);
                                            };

                                            return (
                                                <>
                                                    <Button
                                                        onClick={handleAddPax}
                                                        variant='outlined'
                                                        startIcon={<AddIcon />}
                                                        type='button'
                                                    >
                                                        Add Pax
                                                    </Button>

                                                    {values.passengers.map((p, index) => (
                                                        <div key={index}>
                                                            <Divider>Passenger {index + 1}</Divider>
                                                            <PassengerFieldsContainer>
                                                                <Grid container spacing={2} justifyContent='center'>
                                                                    <Grid item xs={12} md='auto'>
                                                                        <BcmInput
                                                                            variant='filled'
                                                                            label='First name'
                                                                            placeholder='First name'
                                                                            name={`passengers[${index}].firstName`}
                                                                        ></BcmInput>
                                                                    </Grid>

                                                                    <Grid item xs={12} md='auto'>
                                                                        <BcmInput
                                                                            variant='filled'
                                                                            label='Middle initial'
                                                                            placeholder='Middle initial'
                                                                            name={`passengers[${index}].middleInitial`}
                                                                        />
                                                                    </Grid>

                                                                    <Grid item xs={12} md='auto'>
                                                                        <BcmInput
                                                                            variant='filled'
                                                                            label='Last name'
                                                                            placeholder='Last name'
                                                                            name={`passengers[${index}].lastName`}
                                                                        />
                                                                    </Grid>
                                                                    <Grid item xs={12} md='auto' alignSelf='center'>
                                                                        <Tooltip title='Delete'>
                                                                            <span>
                                                                                <IconButton
                                                                                    disabled={
                                                                                        values.passengers.length == 1 &&
                                                                                        index == 0
                                                                                    }
                                                                                    onClick={() =>
                                                                                        handleRemovePax(index)
                                                                                    }
                                                                                    aria-label='delete'
                                                                                >
                                                                                    <DeleteIcon />
                                                                                </IconButton>
                                                                            </span>
                                                                        </Tooltip>
                                                                    </Grid>
                                                                </Grid>
                                                            </PassengerFieldsContainer>
                                                        </div>
                                                    ))}
                                                </>
                                            );
                                        }}
                                    </FieldArray>
                                </Grid>

                                <Grid item alignContent='center' container xs={12} justifyContent='center' spacing={2}>
                                    <Grid item>
                                        <Button
                                            onClick={previousStep}
                                            startIcon={<BackIcon />}
                                            type='button'
                                            variant='contained'
                                            color='info'
                                            aria-label='previous step'
                                        >
                                            Back
                                        </Button>
                                    </Grid>

                                    <Grid item>
                                        <Button variant='contained' type='submit'>
                                            Save
                                        </Button>
                                    </Grid>
                                </Grid>
                            </Grid>
                        </Form>
                    </>
                );
            }}
        </Formik>
    );

    return (
        <>
            <Stepper orientation='horizontal' activeStep={currentStep} alternativeLabel>
                {steps.map((step, index) => (
                    <Step key={index}>
                        <StepLabel>{step.label}</StepLabel>
                    </Step>
                ))}
            </Stepper>
            {currentContent(currentStep)}
        </>
    );
};

export default BookAFlightForm;
