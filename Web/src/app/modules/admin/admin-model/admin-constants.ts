export class AdminRoute {
	static readonly HOME: string = 'home';
	static readonly BLOG: string = 'blog';
	static readonly FILEMEDIA: string = 'media';
	static readonly LANDING: string = 'landing';
	static readonly USER: string = 'user';
    static readonly SHOP: string = 'shop'
}


export class AdminBlogRoute{
	static readonly DEFAULT: string = '';
	static readonly ID:string = 'blog/:id';
	static readonly SEARCH: string = 'blog/search'
}