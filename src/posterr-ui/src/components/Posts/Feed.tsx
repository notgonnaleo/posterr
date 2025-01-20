import React, { useEffect, useState } from "react";
import Grid from "@mui/material/Grid2";
import PostCard from "./PostCard";
import { Box } from "@mui/material";
import PostFactory from "../../factories/PostFactory";
import { FilterOptions } from "../../models/Post";
import FeedItem from "../../models/Post";
import { sampleUserId } from "../../utils/environments";
import { UserContext } from "../../models/Context";
import Pagination from "../../models/Pagination";

interface Params {
  filterOptions: FilterOptions;
  keyWord: string;
}

const Feed = ({ filterOptions, keyWord }: Params) => {
  const mockedUserContext: UserContext = {
    UserId: sampleUserId,
  };
  const [keywordSearch] = useState<string>(keyWord);
  const [userContext] = useState<UserContext>(mockedUserContext);
  const [postList, setPostList] = useState<FeedItem[]>([]);
  const [pagination, setPagination] = useState<Pagination>({
    take: 3,
    skip: 0,
    lastCount: -1, 
  });

  useEffect(() => {
    loadMorePosts();
  }, []);

  const loadMorePosts = async () => {
    let posts: FeedItem[] = [];

    if(keywordSearch != '') {
      const response = await PostFactory.Keyword(keywordSearch);
      posts = response;
    }

    if (filterOptions === FilterOptions.Latest) {
      const response = await PostFactory.getLatestPosts(pagination.take, pagination.skip);
      posts = response;
    } else if (filterOptions === FilterOptions.Trending) {
      const response = await PostFactory.getTrendingPosts(pagination.take, pagination.skip);
      posts = response;
    }
    setPostList(postList.concat(posts));
    setPagination((prevPagination) => ({
      take: prevPagination.take,
      skip: prevPagination.skip + prevPagination.take, 
      lastCount: posts.length
    }));
  };

  return postList.length > 0 ? (
    <>
      <Grid container spacing={2} columns={1}>
        {postList.map((data, index) => (
          <Grid size={{ xs: 12, md: 4 }} key={index}>
            <PostCard data={data} userId={userContext.UserId} />
          </Grid>
        ))}
      </Grid>
      { pagination.lastCount != 0 && (
        <Box mt={2}>
          <button onClick={() => {loadMorePosts()}}>Load More</button>
        </Box>
      )}
    </>
  ) : (
      <>
        { pagination.lastCount != 0 && (
          <Box mt={2}>
            <button onClick={() => {loadMorePosts()}}>Load More</button>
          </Box>
        )}
      </>
  );
};

export default Feed;
