import axios from "axios";
import Post from "../models/Post";

const controller = "api/Post";

const PostFactory = {
    getPosts: async (): Promise<Post[]> => {
        const fakeResponse : Post[] = [
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

        const response = await axios.get<Post[]>(`${controller}/Feed`)
        return fakeResponse;
    }
}

export default PostFactory;