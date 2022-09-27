import '../styles/globals.css';
import type { AppProps } from 'next/app';
import { Container } from '@mui/system';
import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';
import { ReactElement, ReactNode } from 'react';
import { NextPage } from 'next';

export type NextPageWithLayout<P = {}, IP = P> = NextPage<P, IP> & {
    getLayout?: (page: ReactElement) => ReactNode;
};

type AppPropsWithLayout = AppProps & {
    Component: NextPageWithLayout;
};

const darkTheme = createTheme({
    palette: {
        mode: 'dark',
        primary: {
            main: '#007ac1',
        },
        secondary: {
            main: '#82b3c9',
        },
    },
});

function MyApp({ Component, pageProps }: AppPropsWithLayout) {
    // Use the layout defined at the page level, if available
    const getLayout = Component.getLayout ?? ((page) => page);

    return (
        <ThemeProvider theme={darkTheme}>
            <CssBaseline />
            <Container maxWidth='md'>{getLayout(<Component {...pageProps} />)}</Container>
        </ThemeProvider>
    );
}

export default MyApp;
