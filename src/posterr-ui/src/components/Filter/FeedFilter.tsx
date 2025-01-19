import { Box, Chip } from "@mui/material";
import { FilterOptions } from "../../models/Post";

interface Params {
  selectedFilterOption: FilterOptions;
  setFilterOption: React.Dispatch<React.SetStateAction<FilterOptions>>;
}

const FeedFilter: React.FC<Params> = ({ selectedFilterOption, setFilterOption }) => {
  return (
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
      <Box sx={{ display: 'inline-flex', flexDirection: 'row', gap: 3, overflow: 'auto' }}>
        <Chip
          onClick={() => setFilterOption(FilterOptions.Latest)}
          size="medium"
          label="Latest"
          color={selectedFilterOption === FilterOptions.Latest ? 'primary' : 'default'}
        />
        <Chip
          onClick={() => setFilterOption(FilterOptions.Trending)}
          size="medium"
          label="Trending"
          color={selectedFilterOption === FilterOptions.Trending ? 'primary' : 'default'}
        />
      </Box>
    </Box>
  );
};

export default FeedFilter;