import { IEnvironment, IModuleConfig } from "./interface/IEnvironment";

export const mergeNewSetting = ( newConfig: IModuleConfig) => {
    environment.server = Object.assign(newConfig); 
}
  
export const environment:IEnvironment = {
  production: false,
  appSetting: './appSetting.json',
  baseURL: '',
  assetsPath: '/assets'
};