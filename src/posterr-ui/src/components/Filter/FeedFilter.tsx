import { Box, Chip } from "@mui/material";
import Searchbar from "./Searchbar";

const handleClick = () => {
    console.info('You clicked the filter chip.');
  };

const FeedFilter = () => {
    return(
        <Box
        sx={{
          marginTop: '26px',
          display: 'flex',
          flexDirection: { xs: 'column-reverse', md: 'row' },
          width: '100%',
          justifyContent: 'space-between',
          alignItems: { xs: 'start', md: 'center' },
          gap: 4,
          overflow: 'auto',
        }}
      >
        <Box
          sx={{
            display: 'inline-flex',
            flexDirection: 'row',
            gap: 3,
            overflow: 'auto',
          }}
        >
          <Chip onClick={handleClick} size="medium" label="Latest" />
          <Chip onClick={handleClick} size="medium" label="Trending"/>

        </Box>
        <Box
          sx={{
            display: { xs: 'none', sm: 'flex' },
            flexDirection: 'row',
            gap: 1,
            width: { xs: '100%', md: 'fit-content' },
            overflow: 'auto',
          }}
        >
            <Searchbar />
        </Box>
      </Box>
    );
}

export default FeedFilter;