import Box from '@mui/material/Box';
import Header from '../../Header/Header';
import Feed from '../../Posts/Feed';
import CreatePostSection from '../../Posts/CreatePostSection';
import { useState } from 'react';
import { FilterOptions } from '../../../models/Post';
import Pagination from '../../../models/Pagination';

export default function MainContent() {
  const [pagination, setPagination] = useState<Pagination>({
    take: 2,
    skip: 0,
    totalCount: 20
  });
  const [selectedFilterOption, setFilterOption] = useState<FilterOptions>(FilterOptions.Latest);

  const loadMorePosts = () => {
    setPagination((prev) => {
      if (prev.skip + prev.take >= prev.totalCount) {
        return prev;
      }
      return {
        ...prev,
        skip: prev.skip + prev.take,
      };
    });
  };

  return (
    <Box sx={{ flex: 1 }}>
      <Box>
        <Header selectedFilterOption={selectedFilterOption} setFilterOption={setFilterOption} />
      </Box>
      <Box sx={{ mt: 4 }}>
        <CreatePostSection />
      </Box>
      <Box sx={{ mt: 4 }}>
        <Feed pagination={pagination} filterOptions={selectedFilterOption} loadMore={loadMorePosts} />
      </Box>
    </Box>
  );
}
