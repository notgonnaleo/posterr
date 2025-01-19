import { Box } from "@mui/material";
import FeedFilter from "../Filter/FeedFilter";
import { FilterOptions } from "../../models/Post";

interface Params {
    selectedFilterOption: FilterOptions;
    setFilterOption: React.Dispatch<React.SetStateAction<FilterOptions>>;
}

const Header = ({ selectedFilterOption, setFilterOption  }: Params) => {
    return (
        <Box>
            <FeedFilter selectedFilterOption={selectedFilterOption} setFilterOption={setFilterOption} />
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