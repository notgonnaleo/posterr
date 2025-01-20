import { useState } from 'react';
import { Button, Box, TextareaAutosize, styled, FormControl } from '@mui/material';
import { gray } from '../../theme/themePrimitives';
import SendIcon from '@mui/icons-material/Send';
import PostFactory from '../../factories/PostFactory';
import { useNavigate } from 'react-router-dom';
import { UserContext } from '../../models/Context';
import { sampleUserId } from '../../utils/environments';

const TextAreaPost = styled(TextareaAutosize)(({ theme }) => ({
  display: 'flex',
  flexDirection: 'column',
  padding: '10px',
  margin: '0 auto',
  marginBottom: '4px',
  width: '100%',
  minHeight: '120px',
  color: theme.palette.text.primary,
  borderRadius: theme.shape.borderRadius,
  border: `1px solid ${theme.palette.divider}`,
  backgroundColor: theme.palette.background.default,
  fontFamily: theme.typography.fontFamily,
  fontWeight: theme.typography.fontWeightMedium,
  transition: 'border 120ms ease-in',
  '&:hover': {
    borderColor: gray[400],
  },
  '&:focus': {
    borderColor: gray[400],
    borderWidth: '0.5px',
    outline: 'none',
  },
  fontSize: '16px',
  resize: 'none',
}));

const CreatePostSection = () => {
  const navigate = useNavigate();
  const mockedUserContext: UserContext = {
    UserId: sampleUserId,
  };
  const [userContext] = useState<UserContext>(mockedUserContext);
  const [postContent, setPostContent] = useState('');
  const [isSubmitting, setIsSubmitting] = useState(false);

  const clickPost = async () => {
    setIsSubmitting(true);
    try {
      if (postContent.trim() === '') {
        alert('You cannot post an empty message');
        setIsSubmitting(false);
        return;
      }
      const response = await PostFactory.New(userContext.UserId, postContent.trim());
      if (response) {
        navigate('/');
      } else {
        alert('Error');
      }
    } catch (error) {
      console.error(error);
    }
    setIsSubmitting(false);
  };

  return (
    <Box sx={{ maxWidth: '100%', mx: 'auto', padding: 2 }}>
      <FormControl sx={{ width: '100%' }} variant="outlined">
        <TextAreaPost
          placeholder="What's up?"
          sx={{ margin: '4px' }}
          value={postContent}
          onChange={(e) => setPostContent(e.target.value)}
        />
      </FormControl>
      <Box display="flex" justifyContent="flex-end">
        <Box sx={{ margin: '3px' }}>
          <Button
            variant="contained"
            color="primary"
            onClick={clickPost}
            disabled={isSubmitting}
          >
            {isSubmitting ? 'Posting...' : <SendIcon fontSize="medium" />}
          </Button>
        </Box>
      </Box>
    </Box>
  );
};

export default CreatePostSection;
