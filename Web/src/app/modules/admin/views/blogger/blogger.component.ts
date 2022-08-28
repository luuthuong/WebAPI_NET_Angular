import { Component, OnInit } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { EditorCondig } from '../../admin-shared/editorConfig';

@Component({
  selector: 'app-blogger',
  templateUrl: './blogger.component.html',
  styleUrls: ['./blogger.component.scss']
})
export class BloggerComponent implements OnInit {

  public htmlContent = "";
  public editorConfig: AngularEditorConfig = EditorCondig.EDITOR_CONFIG;
  constructor(
  ) { 
  }

  ngOnInit(): void {
  }

}
