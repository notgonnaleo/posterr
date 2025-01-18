import Grid from "@mui/material/Grid2";
import PostCard from "./PostCard";
import { useEffect, useState } from "react";
import { Box } from "@mui/material";
import PostFactory from "../../factories/PostFactory";
import FeedItem from "../../models/Post";

const Feed = () => {
  const [postList, setPostList] = useState<FeedItem[]>([]);

  useEffect(() => {
    getPostsList();
  }, []);

  const getPostsList = async () => {
    const posts = await PostFactory.getPosts();
    setPostList(posts);
  }

  // PROBLEM HERE, NEED TO FIX ASAP
  return (
    postList.length > 0 ? (
    <Grid container spacing={2} columns={1}>
      {postList.map((data, index) => (
        <Grid size={{ xs: 12, md: 4 }} key={index}>
          <PostCard data={data} />
        </Grid>
      ))}
    </Grid>
    ) : <Box>No posts for now! You're all updated.</Box>
  );
};

export default Feed;
