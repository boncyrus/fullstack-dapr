import PageTitle from '../components/page-title/pageTitle';

interface MainLayoutProps {
    title?: string;
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = (props) => {
    return (
        <>
            {props.title ? <PageTitle text={props.title}></PageTitle> : null}
            <main>{props.children}</main>
        </>
    );
};

export default MainLayout;
