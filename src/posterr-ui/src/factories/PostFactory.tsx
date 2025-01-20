import axios from "axios";
import { endpoint } from "../utils/environments";
import FeedResponse from "../models/Post";

const controller = `${endpoint}/api/posting`;

const PostFactory = {
  getLatestPosts: async (take: number, skip: number): Promise<FeedResponse> => {
    const response = await axios.get<FeedResponse>(
      `${controller}/latest?take=${take}&skip=${skip}`
    );
    return response.data;
  },
  getTrendingPosts: async (take: number, skip: number): Promise<FeedResponse> => {
    const response = await axios.get<FeedResponse>(
      `${controller}/trending?take=${take}&skip=${skip}`
    );
    return response.data;
  },
  New: async (authorId: number, content: string): Promise<boolean> => {
    const response = await axios.post<boolean>(`${controller}/new`, {
      AuthorId: authorId,
      PostContent: content,
    });
    return response.data;
  },
  Repost: async (postId: number, userId: number): Promise<boolean> => {
    const response = await axios.post<boolean>(`${controller}/repost`, {
      PostId: postId,
      UserId: userId,
    });
    return response.data;
  },
};

export default PostFactory;
