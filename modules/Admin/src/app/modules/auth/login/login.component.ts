import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@app/service/auth.service';
import { RoutingService } from '@app/service/routing.service';
import { TokenStorageService } from '@app/service/token-storage.service';
import { IAuthLogginRequest } from '@app/shared/model/auth/auth.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { take } from 'rxjs';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
	constructor(
		private authService: AuthService,
		private tokenService: TokenStorageService,
		private spinner: NgxSpinnerService,
		private routingService: RoutingService
		) {}
	formLogin = new FormGroup({
		user: new FormControl('',[Validators.required]),
		pwd: new FormControl('',[Validators.required])
	})
	ngOnInit(): void {}

	public login(){
		const rawvalue = this.formLogin.getRawValue()
		const request:IAuthLogginRequest ={
			userName: rawvalue.user||'',
			password: rawvalue.pwd||''
		}
		this.spinner.show();
		this.authService.loggin(request)
			.pipe(take(1))
			.subscribe({
				next:result=>{
					this.spinner.hide();
					this.tokenService.saveToken(result.token.accessToken)
					this.tokenService.saveRefreshToken(result.token.refreshToken)
					this.routingService.navigateTo(['']);
				},
				complete:()=> {
					this.spinner.hide();
				},
			})
	}
}
