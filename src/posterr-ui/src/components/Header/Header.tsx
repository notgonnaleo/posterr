import { Box } from "@mui/material";
import FeedFilter from "../Filter/FeedFilter";

const Header = () => {
    return (
        <Box>
            <FeedFilter />
            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 4 }}>
                <Box
                    sx={{
                    display: { xs: 'flex', sm: 'none' },
                    flexDirection: 'row',
                    gap: 1,
                    width: { xs: '100%', md: 'fit-content' },
                    overflow: 'auto',
                    }}
                >
                </Box>
            </Box>
        </Box>
      );
}

export default Header;