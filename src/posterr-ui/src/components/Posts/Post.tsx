import React, { useState } from "react";
import { styled, Card, CardContent, CardMedia, Typography } from "@mui/material";
import type PostProps from "../../models/Post";

interface Params {
    data: PostProps
}

const StyledCard = styled(Card)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  padding: 0,
  margin: '0 auto',
  width: '90%',
  height: '100%',
  backgroundColor: theme.palette.background.paper,
  '&:hover': {
    backgroundColor: 'transparent',
    cursor: 'pointer',
  },
  '&:focus-visible': {
    outline: '3px solid',
    outlineColor: 'hsla(210, 98%, 48%, 0.5)',
    outlineOffset: '2px',
  },
}));

const StyledCardContent = styled(CardContent)({
  display: 'flex',
  flexDirection: 'column',
  gap: 4,
  padding: 16,
  flexGrow: 1,
  '&:last-child': {
    paddingBottom: 16,
  },
});

const StyledTypography = styled(Typography)({
  display: '-webkit-box',
  WebkitBoxOrient: 'vertical',
  WebkitLineClamp: 2,
  overflow: 'hidden',
  textOverflow: 'ellipsis',
});

const Post: React.FC<Params> = ({ data }) => {
  const [focusedCardIndex, setFocusedCardIndex] = useState<number | null>(null);

  const handleFocus = () => setFocusedCardIndex(0);
  const handleBlur = () => setFocusedCardIndex(null);

  return (
    <StyledCard
      variant="outlined"
      onFocus={handleFocus}
      onBlur={handleBlur}
      tabIndex={0}
      className={focusedCardIndex === 0 ? 'Mui-focused' : ''}
    >
      {/* <CardMedia
        component="img"
        alt={data.title}
        image={data.img}
        sx={{
          aspectRatio: '16 / 9',
          borderBottom: '1px solid',
          borderColor: 'divider',
        }}
      /> */}
      <StyledCardContent>
        <Typography gutterBottom variant="caption" component="div">
          {data.tag}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
          {data.title}
        </Typography>
        <StyledTypography variant="body2" color="text.secondary" gutterBottom>
          {data.description}
        </StyledTypography>
      </StyledCardContent>
    </StyledCard>
  );
};

export default Post;
