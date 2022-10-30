import { Component, OnInit } from '@angular/core';
import { ToolBarDataTemplate } from 'app/shared/components/topbar/topbar-template-data';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  dataTopbar = ToolBarDataTemplate;
  constructor() { }

  ngOnInit(): void {
  }

  onSearchEvent(event:any){
    console.log(event)
  }
}
