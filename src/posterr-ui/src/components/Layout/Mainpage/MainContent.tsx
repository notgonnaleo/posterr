import Box from '@mui/material/Box';
import Header from '../../Header/Header';
import Feed from '../../Posts/Feed';
import CreatePostSection from '../../Posts/CreatePostSection';
import { useState } from 'react';
import { FilterOptions } from '../../../models/Post';

export default function MainContent() {
  const [selectedFilterOption, setFilterOption] = useState<FilterOptions>(FilterOptions.Latest);

  return(
    <Box sx={{ flex: 1 }}>
      <Box>
        <Header selectedFilterOption={selectedFilterOption} setFilterOption={setFilterOption} />
      </Box>
        <Box sx={{ mt: 4 }}>
          <CreatePostSection />
        </Box>
        <Box sx={{ mt: 4 }}>
          <Feed filterOptions={selectedFilterOption} />
        </Box>
    </Box>
  );
}
