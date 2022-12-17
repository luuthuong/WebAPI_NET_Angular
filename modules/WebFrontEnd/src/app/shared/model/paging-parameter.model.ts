import { OrderDirection } from '../enum/order-direction.enum';

export interface PagingParameterModel<T> {
	pageIndex: number;
	pageSize: number;
	orderBy: PageOrderModel;
    filter: T
}

export class PageOrderModel {
	direction: OrderDirection;
	name: string;
	constructor() {
		this.name = '';
		this.direction = OrderDirection.Ascending;
	}
}
