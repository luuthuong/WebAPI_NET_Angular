export interface IEnvironment{
    production: boolean;
    appSetting: string;
    baseURL: string;
    assetsPath: string;
    server?: IModuleConfig
}

export interface IModuleConfig{

}