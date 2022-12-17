import { ButtonGroupTypeEnum } from './../../enum/button-group-type.enum';
import { IChipOptionModel } from './../../model/chip-group-option.model';
import { Component, Input, OnInit } from '@angular/core';
import { BaseComponent } from '../base.component';
import { MatChipsModule } from '@angular/material/chips';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
	selector: 'chip-option-group',
	templateUrl: './button-option-group.component.html',
	styleUrls: ['./button-option-group.component.scss'],
	standalone: true,
	imports:[
		MatChipsModule,
		CommonModule,
		MatIconModule
	]
})
export class ButtonOptionGroupComponent
	extends BaseComponent
	implements OnInit
{
	currentValue!: IChipOptionModel;
	originData: IChipOptionModel[] = [];
	enumTypeGroup = ButtonGroupTypeEnum;
	typeGroup = ButtonGroupTypeEnum.Chip;
	@Input() set data(value: IChipOptionModel[]) {
		if (value.length) {
			this.originData = value.map((item, index) => {
				return {
					...item,
					id: index,
				};
			});
		}
	}
	@Input() set type(value: number){
		this.typeGroup = value;
	}

	get value() {
		return this.currentValue && this.currentValue.value;
	}

	constructor() {
		super();
	}
	ngOnInit(): void {
		this.currentValue = this.originData && this.originData.filter(x=>!x.disable)[0];
	}
	onSelectChip(chip: IChipOptionModel) {
		if(chip.disable)
			return;
		this.currentValue = chip;
	}
}
