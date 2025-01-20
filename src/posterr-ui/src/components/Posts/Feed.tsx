import Grid from "@mui/material/Grid2";
import PostCard from "./PostCard";
import { useEffect, useState, useRef, useCallback } from "react";
import { Box } from "@mui/material";
import PostFactory from "../../factories/PostFactory";
import FeedItem, { FilterOptions } from "../../models/Post";
import { sampleUserId } from "../../utils/environments";
import { UserContext } from "../../models/Context";
import Pagination from "../../models/Pagination";

interface Params {
  filterOptions: FilterOptions;
  pagination: Pagination;
  loadMore: () => void;
}

const Feed = ({ filterOptions, pagination, loadMore }: Params) => {
  // Mocking the context direct in the component but the best approach would be in the main content page
  // or inside App.tsx, the idea here is just to fake an user context info to make the crud operations 
  // work properly.
  const mockedUserContext: UserContext = {
    UserId: sampleUserId,
  };
  const [userContext] = useState<UserContext>(mockedUserContext);
  const [postList, setPostList] = useState<FeedItem[]>([]);
  const observerRef = useRef<IntersectionObserver | null>(null);

  useEffect(() => {
    getPostsList(pagination.take, pagination.skip, true);
  }, [pagination.skip]);

  useEffect(() => {
    getPostsList(pagination.take, pagination.skip, false);
  }, [filterOptions]);

  const getPostsList = async (take: number, skip: number, append: boolean) => {
    setTimeout(async () => {
      let posts: FeedItem[] = [];
      if (filterOptions === FilterOptions.Latest) {
        posts = await PostFactory.getLatestPosts(take, skip);
      } else if (filterOptions === FilterOptions.Trending) {
        posts = await PostFactory.getTrendingPosts(take, skip);
      }
      setPostList((prev) => (append ? [...prev, ...posts] : posts));
    }, 1000);
  };

  const lastPostRef = useCallback(
    (node: Element | null) => {
      if (observerRef.current) observerRef.current.disconnect();
      observerRef.current = new IntersectionObserver((entries) => {
        if (entries[0].isIntersecting && pagination.skip + pagination.take < pagination.totalCount) {
          loadMore();
        }
      });
      if (node) observerRef.current.observe(node);
    },
    [loadMore, pagination.skip, pagination.take, pagination.totalCount]
  );

  return postList.length > 0 ? (
    <Grid container spacing={2} columns={1}>
      {postList.map((data, index) => (
        <Grid size={{ xs: 12, md: 4 }} key={index} ref={index === postList.length - 1 ? lastPostRef : null}>
          <PostCard data={data} userId={userContext.UserId} />
        </Grid>
      ))}
      {pagination.skip + pagination.take >= pagination.totalCount && (
        <Box sx={{ textAlign: 'center', width: '100%', mt: 2 }}>No more posts to load!</Box>
      )}
    </Grid>
  ) : (
    <Box>No posts for now! You're all updated.</Box>
  );
};

export default Feed;
