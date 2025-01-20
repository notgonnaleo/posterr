import React from "react";
import { styled, Card, CardContent, Typography, IconButton, Box, Button } from "@mui/material";
import RepeatIcon from '@mui/icons-material/Repeat';
import FeedItem from "../../models/Post";
import PostFactory from "../../factories/PostFactory";
import { useNavigate } from "react-router-dom";

interface Params {
    data: FeedItem
    userId: number
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

const PostCard: React.FC<Params> = ({ data, userId }) => {
  const navigate = useNavigate();

  const clickRepost = async () => {
    try {
      // I already have a composite key validation for this on the server-side but
      // im adding another one here because i won't need to waste time and resource calling the api
      // and database and even if the user forces it he wont be able to achieve his goal.
      if(userId == data.postUserId) {
        alert("You cannot repost your own posts")
        return;
      };

      const response = await PostFactory.Repost(data.postId, userId);
      if (response) {
        navigate('/');
      } else {
        alert("Error");
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <StyledCard
      variant="outlined"
      tabIndex={0}
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
          @{data.postUsername}
        </Typography>

        <StyledTypography variant="body2" color="text.primary" gutterBottom>
          {data.postContent}
        </StyledTypography>
        
        <Box sx={{ display: 'flex', justifyContent: 'space-between', marginTop: 'auto' }}>
          <Button onClick={() => {clickRepost()}}>
            <IconButton 
              sx={{ 
                margin: '4px', 
                color: data.repostUserId === userId ? 'blue' : 'primary.main',
              }} 
              color="primary"            >
              <RepeatIcon />
              <Typography variant="inherit" sx={{fontSize: '14px', padding: '2px'}}>
                {data.totalReposts}
              </Typography>
            </IconButton>
          </Button>
        </Box>
      </StyledCardContent>
    </StyledCard>
  );
};

export default PostCard;
