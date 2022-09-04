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
