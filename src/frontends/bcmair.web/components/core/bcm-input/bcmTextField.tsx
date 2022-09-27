import { TextField } from '@mui/material';
import { Field } from 'formik';
import React from 'react';

export const BcmInput: React.FC<any> = (props) => {
    return <Field {...props} fullWidth as={TextField}></Field>;
};
