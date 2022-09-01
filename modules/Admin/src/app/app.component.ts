import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { APP_ROUTE } from './shared/constant/routing.constant';


interface ISideBar {
	title: string;
	route?: string;
	children?: ISideBar[];
}
const SIDEBAR_DATA: ISideBar[] = [
  {
    title: 'Home',
    route: APP_ROUTE.HOME,
  },
  {
    title: 'Blog',
    route: APP_ROUTE.BLOG,
  },
  {
    title: 'File Media',
    route: APP_ROUTE.FILEMEDIA
  },
  {
    title: 'Landing Page',
    route: APP_ROUTE.LANDING,
  },
  {
    title: 'User',
    children:[
      {
        title:'Manage User',
      },
      {
        title:'Edit User',
        route:APP_ROUTE.USER
      }
    ]
  },
  {
    title: 'Shop',
    route: APP_ROUTE.SHOP,
  },
];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Admin';
  public treeControl = new NestedTreeControl<ISideBar>(
		(node) => node.children
	);
	public dataSource = new MatTreeNestedDataSource<ISideBar>();
	public hasChild = (_: number, node: ISideBar) => !!node.children && node.children.length > 0;

	constructor() {
    this.dataSource.data = SIDEBAR_DATA;
  }
  ngOnInit(): void {
    
  }
}
