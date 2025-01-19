import React, { useState } from "react";
import { styled, Card, CardContent, Typography, IconButton, Box } from "@mui/material";
import RepeatIcon from '@mui/icons-material/Repeat';
import FeedItem from "../../models/Post";

interface Params {
    data: FeedItem
}

const StyledCard = styled(Card)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  padding: 0,
  margin: '0 auto',
  width: '60%',
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

const PostCard: React.FC<Params> = ({ data }) => {
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
      <StyledCardContent>
        {/* TODO: Come back here and make better styles for this  */}
        <Typography sx={{display: 'flex', alignItems: 'center'}} gutterBottom variant="caption" component="div">
          {data.repostUsername && (
            <Box>
              <RepeatIcon fontSize="small" />{` @${data.repostUsername} reposted `}
            </Box>
          )}
        </Typography>
        
        <Typography gutterBottom variant="h6" component="div">
          @{data.authorName}
        </Typography>

        <StyledTypography variant="body2" color="text.primary" gutterBottom>
          {data.postContent}
        </StyledTypography>
        
        <Box sx={{ display: 'flex', justifyContent: 'space-between', marginTop: 'auto' }}>
          <Box>
            <IconButton sx={{margin: '4px'}} color="primary">
              <RepeatIcon />
              <Typography variant="inherit" sx={{fontSize: '14px', padding: '2px'}}>
                {data.totalReposts}
              </Typography>
            </IconButton>
          </Box>
        </Box>
      </StyledCardContent>
    </StyledCard>
  );
};

export default PostCard;
