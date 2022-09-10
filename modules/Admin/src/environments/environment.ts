import { IEnvironment, IModuleConfig } from './interface/IEnvironment';

export const mergeNewSetting = (newConfig: IModuleConfig) => {
	environment.server = Object.assign(newConfig);
};

export const environment: IEnvironment = {
	production: false,
	baseURL: 'https://localhost:44343/api/',
	assetsPath: '/assets',
	TOKEN_KEY: 'auth-token',
	TOKEN_USER: 'auth-user',
	TOKEN_REFRESH: 'refresh-token',
};
