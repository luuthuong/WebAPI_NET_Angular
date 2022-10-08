export interface IProductModel {
	id: string;
	name: string;
	title: string;
	src: string;
	price?: string;
	content?: string;
	gallerys?: IProductGallery[];
}

export interface IProductGallery{
	id: string;
	name: string;
	src: string;
}
