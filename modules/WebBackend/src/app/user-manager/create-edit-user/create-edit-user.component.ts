import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-edit-user',
  templateUrl: './create-edit-user.component.html',
  styleUrls: ['./create-edit-user.component.scss']
})
export class CreateEditUserComponent implements OnInit {
  title: string = 'Create new user';
  constructor() { }

  ngOnInit(): void {
  }

  onCreateNewUser(){
    console.log('on register')
  }
}
