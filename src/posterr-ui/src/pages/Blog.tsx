import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import AppTheme from '../theme/AppTheme';
import AppAppBar from '../components/Layout/Navbar/AppAppBar';
import MainContent from '../components/Layout/Mainpage/MainContent';
import Footer from '../components/Layout/Footer/Footer';

// For now, Im just letting this page like this because I will come back and change it
// im more focused on making the main requirements first.
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
            flexDirection: { xs: 'column', md: 'row' },
            my: 16,
            gap: 4,
          }}
        >
          <MainContent />
        </Container>
      <Footer />
    </AppTheme>
  );
}
