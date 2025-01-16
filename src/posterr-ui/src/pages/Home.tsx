import React from 'react';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import IconButton from '@mui/material/IconButton';
import Avatar from '@mui/material/Avatar';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';

const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#1DA1F2',
    },
    background: {
      default: '#15202B',
      paper: '#192734',
    },
    text: {
      primary: '#FFFFFF',
      secondary: '#8899A6',
    },
  },
});

const tweets = [
  { id: 1, user: 'User1', content: 'This is my first tweet!' },
  { id: 2, user: 'User2', content: 'Hello world, loving this app!' },
];

const Homepage: React.FC = () => {
  const handleTweet = () => {
    alert('Tweet posted!');
  };

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container maxWidth="lg">
        {/* Top Navigation Bar */}
        <AppBar position="sticky" color="default" elevation={0}>
          <Toolbar sx={{ borderBottom: 1, borderColor: 'divider' }}>
            <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
              Home
            </Typography>
            <IconButton color="inherit">
              <Avatar src="https://via.placeholder.com/40" alt="Profile" />
            </IconButton>
          </Toolbar>
        </AppBar>

        {/* Main Content */}
        <main>
          {/* Tweet Box */}
          <Paper
            elevation={1}
            sx={{
              padding: 2,
              marginTop: 3,
              marginBottom: 3,
            }}
          >
            <Typography variant="h6" gutterBottom>
              What's happening?
            </Typography>
            <TextField
              fullWidth
              multiline
              rows={3}
              placeholder="Share your thoughts..."
              variant="outlined"
              sx={{ mb: 2 }}
            />
            <Button variant="contained" color="primary" onClick={handleTweet}>
              Tweet
            </Button>
          </Paper>

          {/* Tweets Feed */}
          <Grid container spacing={3}>
            {tweets.map((tweet) => (
              <Grid item key={tweet.id} xs={12} md={6}>
                <Paper elevation={1} sx={{ padding: 2 }}>
                  <Typography variant="body1" color="primary">
                    {tweet.user}
                  </Typography>
                  <Typography variant="body2" color="text.secondary">
                    {tweet.content}
                  </Typography>
                </Paper>
              </Grid>
            ))}
          </Grid>
        </main>
      </Container>
    </ThemeProvider>
  );
};

export default Homepage;
