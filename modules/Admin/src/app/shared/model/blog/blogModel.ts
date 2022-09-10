export interface BlogOverviewModel {
	id: string;
	title: string;
	srcImage: string;
	author: string;
	category: string;
	tag: string;
    published: boolean;
	createdDate: Date;
	updatedDate: Date;
}


export interface BlogModel {
	id: string;
	title: string;
	metaTitle: string;
	authorId: string;
	authorName: string;
	slug: string;
	summary: string;
	srcImage: string;
	author: string;
	tag: string;
    published: boolean;
	publishedDate: Date;
	createdDate: Date;
	updatedDate: Date;
}
