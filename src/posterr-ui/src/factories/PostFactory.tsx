import axios from "axios";
import FeedItem from "../models/Post";
import { endpoint } from "../utils/environments";

const controller = `${endpoint}/api/posting`;

const PostFactory = {
    getLatestPosts: async (): Promise<FeedItem[]> => {
        const response = await axios.get<FeedItem[]>(`${controller}/latest`)
        return response.data;
    },
    getTrendingPosts: async (): Promise<FeedItem[]> => {
        const response = await axios.get<FeedItem[]>(`${controller}/trending`)
        return response.data;
    },
    Repost: async (postId: number, userId: number): Promise<boolean> => {
        const response = await axios.post<boolean>(`${controller}/repost`, {
            PostId: postId,
            UserId: userId
        })
        return response.data;
    }
}

export default PostFactory;