import { MatCardModule } from '@angular/material/card';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatRippleModule } from '@angular/material/core';
import { MatCheckboxModule} from '@angular/material/checkbox';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    MatSnackBarModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatCardModule,
    MatRippleModule,
    MatCheckboxModule
  ]
})
export class MaterialModule { }
