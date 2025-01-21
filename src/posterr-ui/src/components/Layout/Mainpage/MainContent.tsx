import Box from "@mui/material/Box";
import Header from "../../Header/Header";
import Feed from "../../Posts/Feed";
import CreatePostSection from "../../Posts/CreatePostSection";
import { useState } from "react";
import { FilterOptions } from "../../../models/Post";
import { TextField, Button } from "@mui/material";

export default function MainContent() {
  const [selectedFilterOption, setFilterOption] = useState<FilterOptions>(
    FilterOptions.Latest
  );
  const [keywordSearch, setKeywordSearch] = useState<string>("");
  const [searchInput, setSearchInput] = useState<string>("");

  const handleSearch = () => {
    setKeywordSearch(searchInput);
  };

  return (
    <Box sx={{ flex: 1 }}>
      <Box>
        <Header
          selectedFilterOption={selectedFilterOption}
          setFilterOption={setFilterOption}
        />
      </Box>

      <Box sx={{ mt: 4, display: "flex", gap: 2, justifyContent: "center" }}>
        <TextField
          label="Search by Keyword"
          variant="outlined"
          value={searchInput}
          onChange={(e) => setSearchInput(e.target.value)}
          fullWidth
        />
        <Button variant="contained" onClick={handleSearch}>
          Search
        </Button>
      </Box>

      <Box sx={{ mt: 4 }}>
        <CreatePostSection />
      </Box>

      <Box sx={{ mt: 4 }}>
        <Feed
          keyWord={keywordSearch}
          filterOptions={selectedFilterOption}
        />
      </Box>
    </Box>
  );
}
