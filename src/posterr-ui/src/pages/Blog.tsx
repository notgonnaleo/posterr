import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import AppTheme from '../theme/AppTheme';
import AppAppBar from '../components/Layout/Navbar/AppAppBar';
import MainContent from '../components/Layout/Mainpage/MainContent';
import Latest from '../components/Topics/Latest';
import Footer from '../components/Layout/Footer/Footer';

export default function Blog(props: { disableCustomTheme?: boolean }) {
  return (
    <AppTheme {...props}>
      <CssBaseline enableColorScheme />
      <AppAppBar />
      <Container
          maxWidth="lg"
          component="main"
          sx={{
            display: 'flex',
            flexDirection: { xs: 'column', md: 'row' }, // coluna para telas pequenas e linha para telas grandes
            my: 16,
            gap: 4,
          }}
        >
          <MainContent />
          {/* <Latest /> */}
        </Container>
      <Footer />
    </AppTheme>
  );
}
