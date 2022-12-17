import { OrderDirection } from "../enums/order-direction.enum";

export interface PagingParameterModel<T>{
    pageSize: number;
    pageIndex: number;
    filterObject: T;
    orderBy: PageOrderModel,
}

export class PageOrderModel {
	direction: OrderDirection;
	name: string;
	constructor() {
		this.name = '';
		this.direction = OrderDirection.ASC;
	}
}
