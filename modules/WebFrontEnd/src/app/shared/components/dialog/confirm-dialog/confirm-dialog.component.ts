import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-confirm-dialog',
  styleUrls: ['./confirm-dialog.component.scss'],
  template: `
    <p>confirm-dialog works!</p>
  `,
  standalone: true
})
export class ConfirmDialogComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
