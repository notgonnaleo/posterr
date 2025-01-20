import Grid from "@mui/material/Grid2";
import PostCard from "./PostCard";
import { useEffect, useState } from "react";
import { Box } from "@mui/material";
import PostFactory from "../../factories/PostFactory";
import { FilterOptions } from "../../models/Post";
import FeedItem from "../../models/Post";
import { sampleUserId } from "../../utils/environments";
import { UserContext } from "../../models/Context";
import Pagination from "../../models/Pagination";

interface Params {
  filterOptions: FilterOptions;
}

const Feed = ({ filterOptions }: Params) => {
  const mockedUserContext: UserContext = {
    UserId: sampleUserId,
  };
  const [userContext] = useState<UserContext>(mockedUserContext);
  const [postList, setPostList] = useState<FeedItem[]>([]);
  const [pagination] = useState<Pagination>({
    take: 3,
    skip: 0,
    totalRowCount: 0,
  });

  useEffect(() => {
    getPostsList(pagination.take, pagination.skip);
  }, [filterOptions]);

  useEffect(() => {
    getPostsList(pagination.take, pagination.skip);
  }, [pagination.skip, pagination.take])

  const getPostsList = async (take: number, skip: number) => {
    let posts: FeedItem[] = [];

    if (filterOptions === FilterOptions.Latest) {
      const response = await PostFactory.getLatestPosts(take, skip);
      posts = response.feedItems;
    } else if (filterOptions === FilterOptions.Trending) {
      const response = await PostFactory.getTrendingPosts(take, skip);
      posts = response.feedItems;
    }
    setPostList(posts);
  };

  return postList.length > 0 ? (
    <Grid container spacing={2} columns={1}>
      {postList.map((data, index) => (
        <Grid
          size={{ xs: 12, md: 4 }}
          key={index}
        >
          <PostCard data={data} userId={userContext.UserId} />
        </Grid>
      ))}
    </Grid>
  ) : (
    <Box>No posts for now! You're all updated.</Box>
  );
};

export default Feed;