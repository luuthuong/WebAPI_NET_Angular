import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'app/shared/components/base-component';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.scss']
})
export class UserManagerComponent extends BaseComponent implements OnInit {

  constructor() { 
    super();
  }

  ngOnInit(): void {
  }

  navigateTo(path: string[]){
    this.router.navigate(path);
  }

}
