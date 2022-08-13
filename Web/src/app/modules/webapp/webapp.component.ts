import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { takeUntil } from 'rxjs';
import { FileMediaService } from 'src/app/services/webapi/file-media.service';
import { UploadFileModelRequest } from 'src/app/shared/model/FileModel';
import { BaseComponent } from './../../shared/components/BaseComponent';

@Component({
  selector: 'webapp',
  templateUrl: './webapp.component.html',
  styleUrls: ['./webapp.component.scss']
})
export class WebappComponent extends BaseComponent implements OnInit {

  public arr = new Array(100).fill(0);
  public file?:File;
  constructor(
    private _fileService: FileMediaService
  ) {
    super();

  }

  ngOnInit(): void {
    this._fileService.GetAllFileMedia()
      .pipe(takeUntil(this.ngUnSubcribe))
      .subscribe(res => {
        console.log("🚀 - ngOnInit - res", res)
      })
  }
  public uploadFile(){
    const request = {
      file:this.file,
      fileName : "thuong upload",
      type: 1
    } as UploadFileModelRequest;
    this._fileService.uploadFileMedia(request).pipe(takeUntil(this.ngUnSubcribe)).subscribe(res=>{
      console.log("🚀 - this._fileService.uploadFileMedia - res", res)
      })
  }
  getFile($event:any){
    console.log()
    this.file = $event.target.files[0];
  }

}
