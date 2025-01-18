import axios from "axios";
import FeedItem from "../models/Post";
import { endpoint } from "../utils/environments";

const controller = `${endpoint}/api/posting`;

const PostFactory = {
    getPosts: async (): Promise<FeedItem[]> => {
        const response = await axios.get<FeedItem[]>(`${controller}/latest`)
        return response.data;
    }
}

export default PostFactory;