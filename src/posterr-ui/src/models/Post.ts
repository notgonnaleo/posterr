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

export enum FilterOptions {
    Latest = 0,
    Trending = 1,
}