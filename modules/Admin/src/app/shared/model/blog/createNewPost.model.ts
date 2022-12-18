export interface CreateNewPostRequest {
	title: string;
	category?: string[];
	metaTitle: string;
	slug: string;
	parentId?: string;
	content: string;
	summary: string;
}
