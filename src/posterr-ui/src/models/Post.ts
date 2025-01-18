// export default interface Post {
//     img: string;
//     tag: string;
//     title: string;
//     description: string;
// }

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