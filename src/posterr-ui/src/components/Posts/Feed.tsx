import Grid from "@mui/material/Grid2";
import PostCard from "./PostCard";
import { useEffect, useState } from "react";
import { Box } from "@mui/material";
import PostFactory from "../../factories/PostFactory";
import FeedItem, { FilterOptions } from "../../models/Post";

interface Params {
  filterOptions: FilterOptions
}

const Feed = ({ filterOptions }: Params)=> {
  const [postList, setPostList] = useState<FeedItem[]>([]);

  useEffect(() => {
    getPostsList();
  }, []);

  useEffect(() => {
    getPostsList();
  }, [filterOptions]);

  const getPostsList = async () => {
    let posts: FeedItem[] = [];
    if(filterOptions === FilterOptions.Latest) {
      posts = await PostFactory.getLatestPosts();
    } else if (filterOptions === FilterOptions.Trending) {
      posts = await PostFactory.getTrendingPosts();
    }
    setPostList(posts);
  }

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
