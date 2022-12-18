import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';
import { DateFormatStringConst } from '../constant/format.constants';
@Pipe({
	name: 'appdate',
})
export class AppDatePipe implements PipeTransform {
	transform(value: any, args?: any): any {
		if (!value) return;
		let valueFormat = '';
		const type = args || DateFormatStringConst.SHORT_DATE;
		switch (type) {
			case DateFormatStringConst.LONG_DATE:
				valueFormat = 'MM/DD/YYYY hh:mm:ss A';
				break;
			case DateFormatStringConst.LONG_DATE_WITHOUT_SECOND:
				valueFormat = 'MM/DD/YYYY hh:mm A';
				break;
			default:
				valueFormat = 'MM/DD/YYYY';
				break;
		}
		return moment(value).format(valueFormat);
	}
}
