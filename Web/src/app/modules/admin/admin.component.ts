import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { NgxSpinnerService } from 'ngx-spinner';
import { AdminRoute } from './admin-model/admin-constants';

interface ISideBar {
	title: string;
	route?: string;
	children?: ISideBar[];
}
const SIDEBAR_DATA: ISideBar[] = [
  {
    title: 'Home',
    route: AdminRoute.HOME,
  },
  {
    title: 'Blog',
    route: AdminRoute.BLOG,
  },
  {
    title: 'File Media',
    route: AdminRoute.FILEMEDIA
  },
  {
    title: 'Landing Page',
    route: AdminRoute.LANDING,
  },
  {
    title: 'User',
    children:[
      {
        title:'Manage User',
      },
      {
        title:'Edit User',
        route:AdminRoute.USER
      }
    ]
  },
  {
    title: 'Shop',
    route: AdminRoute.SHOP,
  },
];

@Component({
	selector: 'admin',
	templateUrl: './admin.component.html',
	styleUrls: ['./admin.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class AdminComponent implements OnInit {
	

	public treeControl = new NestedTreeControl<ISideBar>(
		(node) => node.children
	);
	public dataSource = new MatTreeNestedDataSource<ISideBar>();
	public hasChild = (_: number, node: ISideBar) => !!node.children && node.children.length > 0;

	constructor() {
    this.dataSource.data = SIDEBAR_DATA;
  }

	ngOnInit(): void {}
}
