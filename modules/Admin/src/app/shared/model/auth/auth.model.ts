export interface IAuthorModel {
	status: string;
	token: {
		accessToken: string;
		refreshToken: string;
	};
}

export interface IAuthLogginRequest {
	userName?: string;
	email?: string;
	password: string;
	isRemember?: boolean;
}
