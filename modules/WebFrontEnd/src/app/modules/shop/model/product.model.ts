export interface IProductModel {
	name: string;
	title: string;
	src: string;
	price?: number;
	content?: string;
	gallerys?: IProductGallery[];
}

export interface IProductGallery{
	name: string;
	src: string;
}
