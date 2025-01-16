import Grid from "@mui/material/Grid2";
import Post from "./Post";
import PostProps from "../../models/Post";

const cardData : PostProps[] = [
  {
    img: "https://picsum.photos/800/450?random=1",
    tag: "Engineering",
    title: "Revolutionizing software development with cutting-edge tools",
    description:
      "Our latest engineering tools are designed to streamline workflows and boost productivity. Discover how these innovations are transforming the software development landscape.",
  },
  {
    img: "https://picsum.photos/800/450?random=2",
    tag: "Product",
    title: "Innovative product features that drive success",
    description:
      "Explore the key features of our latest product release that are helping businesses achieve their goals. From user-friendly interfaces to robust functionality, learn why our product stands out.",
  },
];

const Feed = () => {
  return (
    <Grid container spacing={2} columns={1}>
      {cardData.map((data, index) => (
        <Grid  size={{ xs: 12, md: 4 }} key={index}>
          <Post data={data} />
        </Grid>
      ))}
    </Grid>
  );
};

export default Feed;
