import { IMenuNavigate } from './../../model/menu-navigate.interface';
import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ToolBarDataTemplate } from './topbar-template-data';
import { debounce, debounceTime, takeUntil } from 'rxjs';
import { BaseComponent } from '../base.component';

@Component({
	selector: 'app-topbar',
	templateUrl: './topbar.component.html',
	styleUrls: ['./topbar.component.scss'],
	encapsulation: ViewEncapsulation.None
})
export class TopbarComponent extends BaseComponent implements OnInit {
	@Input() data : IMenuNavigate[] =[];
	@Output() onSearchEvent = new EventEmitter<any>();


	inputSearchControl = new FormControl('');
	constructor() {
		super();
		this.inputSearchControl.valueChanges
		.pipe(takeUntil(this.ngUnsubscribe),debounceTime(1000))
		.subscribe(result =>{
			this.onSearchEvent.emit(result);
		});
	}

	ngOnInit(): void {
	
	}



}
