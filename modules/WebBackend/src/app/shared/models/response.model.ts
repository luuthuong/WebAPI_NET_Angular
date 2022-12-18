import { ResponseTypeEnum } from "../enums/responseType.enum";
export interface IResponseBase<T> {
    message: string;
    data: T;
    responseStatus: ResponseTypeEnum;
}
