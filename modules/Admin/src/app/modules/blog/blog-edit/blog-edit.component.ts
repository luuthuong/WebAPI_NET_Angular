import { Component, OnInit, SecurityContext } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { Editor, toHTML, Toolbar, Validators } from 'ngx-editor';
import { takeUntil } from 'rxjs';

@Component({
  selector: 'app-blog-edit',
  templateUrl: './blog-edit.component.html',
  styleUrls: ['./blog-edit.component.scss'],
})
export class BlogEditComponent extends Basecomponent implements OnInit {
  public editor = new Editor();

  public renderHtmlContent: SafeHtml | null = '';
  public html = ''
  public formEditor = new FormGroup({
    editorContent: new FormControl('', Validators.required()),
  });

  public toolbar: Toolbar = [
    ['bold', 'italic'],
    ['underline', 'strike'],
    ['code', 'blockquote'],
    ['ordered_list', 'bullet_list'],
    [{ heading: ['h1', 'h2', 'h3', 'h4', 'h5', 'h6'] }],
    ['link', 'image', 'code'],
    ['text_color', 'background_color'],
    ['align_left', 'align_center', 'align_right', 'align_justify'],
    ['format_clear'],
  ];

  constructor(private sanitize: DomSanitizer) {
    super();
    
    this.editor.valueChanges.pipe(takeUntil(this.ngUnsubcribe)).subscribe(result=>{
      this.html = toHTML(result)
    })
  }

  ngOnInit(): void {
    
    this.renderHtmlContent = this.sanitizeHtmlContent('<p><span style="color:#0e8a16;">qweqweqweqwe</span></p>') 
    console.log(this.renderHtmlContent)
  }

  public override ngOnDestroy(): void {
    this.editor.destroy();
  }

  public exportHtml() {
    if (this.formEditor.get('editorContent')?.value) {
      console.log(
        'Sanitialization',
        this.sanitizeHtmlContent(this.formEditor.get('editorContent')?.value)
      );
      this.renderHtmlContent = this.sanitizeHtmlContent(
        this.formEditor.get('editorContent')?.value
      );
    }
  }

  public sanitizeHtmlContent(htmlString: any): SafeHtml | null {
    return this.sanitize.sanitize(SecurityContext.HTML, htmlString);
  }
}
