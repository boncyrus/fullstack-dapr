import { Typography } from '@mui/material';

interface PageTitleProps {
    text: string;
}

const PageTitle: React.FC<PageTitleProps> = (props) => {
    return (
        <>
            <h1>{props.text}</h1>
        </>
    );
};

export default PageTitle;
