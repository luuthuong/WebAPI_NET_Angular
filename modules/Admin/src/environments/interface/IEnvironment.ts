export interface IEnvironment{
    production: boolean;
    appSetting?: IAppSetting;
    baseURL: string;
    assetsPath: string;
    server?: IModuleConfig
}

interface IAppSetting{
	apiURL: string;
	loginURL: string;
}

export interface IModuleConfig{

}
