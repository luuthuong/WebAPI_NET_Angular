import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
import { ToastService } from 'app/services/toast.service';
import { BaseComponent } from 'app/shared/components/base-component';
import { ILoginRequest } from 'app/shared/models/requests/login-request.model';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { catchError, of, takeUntil } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports:[
    MatCardModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    CommonModule,
    MatInputModule,
    MatButtonModule,
  ],
  providers:[
    ToastService,
  ]
})
export class LoginComponent extends BaseComponent implements OnInit {
  form: FormGroup = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl('', [Validators.required]),
  });
  returnUrl: string = ''
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authService: AuthService,
  ) { 
    super();
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'] || 'dashboard';

  }

  submit() {
    this.form.markAllAsTouched();
    if(this.form.valid){
      const request = this.form.getRawValue() as ILoginRequest;
      this.authService.login(request)
      .pipe(takeUntil(this.ngUnSubcribe), catchError(err =>{
        if([401,403,400].includes(err.status)){
          ToastService.error('Tên đăng nhập hoặc mật khẩu không hợp lệ');
        }
        return of();
      })).subscribe(result =>{
        if(result && result.token){
          console.log(result)
          ToastService.success('Đăng nhập thành công');
          this.router.navigate([this.returnUrl]);
        }
      })

    }
  }

}
