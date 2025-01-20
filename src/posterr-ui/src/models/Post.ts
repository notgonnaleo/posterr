import Pagination from "./Pagination";

export default interface FeedItem {
    postId: number;
    postContent: string;
    totalReposts: number;
    authorId: number;
    authorName: string;
    postDate: Date;
    repostUserId?: number | null;
    repostUsername?: string | null;
    repostDate?: Date | null;
}

export default interface FeedResponse {
    feedItems : FeedItem[],
    pagination: Pagination
}

export enum FilterOptions {
    Latest = 0,
    Trending = 1,
}

