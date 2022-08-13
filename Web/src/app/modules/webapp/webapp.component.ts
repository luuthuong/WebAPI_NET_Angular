import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { takeUntil, throwIfEmpty } from 'rxjs';
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
  public file!:File;
  public fileNames = new FormControl([]);
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
    if(!this.file) return;
    const formData = new FormData();
    formData.append("file", this.file);
    formData.append("fileName", this.file,this.file.name);
    formData.append("type", "1")
    formData.append("fileUrl", "https://google.com");
    this._fileService.uploadFileMedia(formData).pipe(takeUntil(this.ngUnSubcribe)).subscribe(res=>{
      console.log("🚀 - this._fileService.uploadFileMedia - res", res)
      })
  }
  getFile($event:any){
    this.file = $event.target.files[0] as File;
  }
}
