import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import AvatarGroup from '@mui/material/AvatarGroup';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import { styled } from '@mui/material/styles';

const articleInfo = [
  {
    tag: 'Engineering',
    title: 'The future of AI in software engineering',
    authors: [
      { name: 'Remy Sharp', avatar: '/static/images/avatar/1.jpg' },
      { name: 'Travis Howard', avatar: '/static/images/avatar/2.jpg' },
    ],
  },
  {
    tag: 'Product',
    title: 'Driving growth with user-centric product design',
    authors: [{ name: 'Erica Johns', avatar: '/static/images/avatar/6.jpg' }],
  },
  {
    tag: 'Design',
    title: 'Embracing minimalism in modern design',
    authors: [{ name: 'Kate Morrison', avatar: '/static/images/avatar/7.jpg' }],
  },
  {
    tag: 'Company',
    title: 'Cultivating a culture of innovation',
    authors: [{ name: 'Cindy Baker', avatar: '/static/images/avatar/3.jpg' }],
  },
  {
    tag: 'Engineering',
    title: 'Advancing cybersecurity with next-gen solutions',
    authors: [
      { name: 'Agnes Walker', avatar: '/static/images/avatar/4.jpg' },
      { name: 'Trevor Henderson', avatar: '/static/images/avatar/5.jpg' },
    ],
  },
];

const StyledContainer = styled(Box)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  gap: theme.spacing(2),
  backgroundColor: theme.palette.background.paper,
  borderRadius: theme.shape.borderRadius,
  boxShadow: theme.shadows[1],
  padding: theme.spacing(2),
  width: '100%',
  maxWidth: 300,
  height: 350,
  overflowY: 'auto',
}));

const StyledItem = styled(Box)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'row',
  alignItems: 'center',
  justifyContent: 'space-between',
  padding: theme.spacing(1),
  borderRadius: theme.shape.borderRadius,
  transition: 'background-color 0.2s ease',
  '&:hover': {
    backgroundColor: theme.palette.action.hover,
    cursor: 'pointer',
  },
}));

const StyledTitle = styled(Typography)({
  fontWeight: 500,
  fontSize: '0.875rem',
  overflow: 'hidden',
  textOverflow: 'ellipsis',
  whiteSpace: 'nowrap',
});

const StyledTag = styled(Typography)(({ theme }) => ({
  color: theme.palette.text.secondary,
  fontSize: '0.75rem',
}));

function TrendItem() {
  return (
    <StyledItem>
      <Box>
        <StyledTag>asdasd</StyledTag>
        <StyledTitle>"title"</StyledTitle>
      </Box>
      {/* <AvatarGroup max={2} spacing={8}>
        {authors.map((author, index) => (
          <Avatar
            key={index}
            alt={author.name}
            src={author.avatar}
            sx={{ width: 24, height: 24 }}
          />
        ))}
      </AvatarGroup> */}
    </StyledItem>
  );
}

export default function Latest() {
  return (
    <StyledContainer sx={{ flex: 1, display: { xs: 'none', md: 'block' } }}>
      <Typography variant="h6" gutterBottom>
        Trending Topics
      </Typography>
      {articleInfo.map((article, index) => (
        <TrendItem
        />
      ))}
    </StyledContainer>
  );
}