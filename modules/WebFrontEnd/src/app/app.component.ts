import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { BaseComponent } from './shared/components/base.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends BaseComponent implements OnInit {
  globalLoading = true;
  constructor(
    public authService: AuthService,
  ){
    super();
  }
  ngOnInit(): void {
    this.globalLoading = this.environment.globalLoading;
  }
}
