import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({
	name: 'appDate',
})
export class DatePipe implements PipeTransform {
	transform(value: Date, ...args: any[]): string {
		if (!value) return '';
		let valueFormat = 'DD/MM/YYYY';
		return moment(value).format(valueFormat);
	}
}
