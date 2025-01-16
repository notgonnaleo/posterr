import { FormControl, OutlinedInput, InputAdornment, Box } from "@mui/material";
import SearchRoundedIcon from '@mui/icons-material/SearchRounded';

const Searchbar = () => {
    return(
        <Box>
            <Box>
                <FormControl sx={{ width: { xs: '100%', md: '25ch' } }} variant="outlined">
                    <OutlinedInput
                    size="small"
                    id="search"
                    placeholder="Search…"
                    sx={{ flexGrow: 1 }}
                    startAdornment={
                        <InputAdornment position="start" sx={{ color: 'text.primary' }}>
                        <SearchRoundedIcon fontSize="small" />
                        </InputAdornment>
                    }
                    inputProps={{
                        'aria-label': 'search',
                    }}
                    />
                </FormControl>
            </Box>
            {/* <Box>
                <IconButton size="small" aria-label="Search">
                    <Search />
                </IconButton>
            </Box> */}
        </Box>
    );
}

export default Searchbar;