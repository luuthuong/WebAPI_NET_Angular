export interface IEnvironment{
    production: boolean;
    appSetting?: IAppSetting;
    baseURL: string;
    assetsPath: string;
    server?: IModuleConfig;
	TOKEN_KEY: string;
	TOKEN_REFRESH: string;
	TOKEN_USER: string;
}

interface IAppSetting{
	apiURL: string;
	loginURL: string;
}

export interface IModuleConfig{

}
