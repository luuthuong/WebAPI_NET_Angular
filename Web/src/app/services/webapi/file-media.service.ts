import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadFileModelRequest } from 'src/app/shared/model/FileModel';
import { HttpBaseService } from '../http-base.service';

@Injectable({
  providedIn: 'root'
})
export class FileMediaService extends HttpBaseService {

  private PATH = "/FileMedia"
  public GetAllFileMedia():Observable<any>{
    return this.get(this.PATH);
  }
  public uploadFileMedia(request:UploadFileModelRequest):Observable<any>{
    return this.post(this.PATH,request);
  }
}
