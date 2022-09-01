import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blog-overview',
  templateUrl: './blog-overview.component.html',
  styleUrls: ['./blog-overview.component.scss']
})
export class BlogOverviewComponent implements OnInit {
  blogs = new Array(100).fill(0);
  constructor() { }

  ngOnInit(): void {
  }

}
