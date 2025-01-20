export default interface FeedItem {
    postId: number;
    postContent: string;
    totalReposts: number;
    dateCreated: Date;
    postUserId: number;
    postUsername: string;
    repostId: number;
    repostUserId: number;
    repostUsername: string;
    repostDate: Date;
    isRepost: boolean;
}

export enum FilterOptions {
    Latest = 0,
    Trending = 1,
}

