import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponse';
import { ResponseModel } from '../models/response';
import { SiparisModel } from '../models/siparis';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SiparisService {

  constructor(
    private toastrService: ToastrService,
    private httpClient: HttpClient
  ) { }

  getAll():Observable<ListResponseModel<SiparisModel>>{
    let api = environment.apiURL+"GetAll";
    return this.httpClient.get<ListResponseModel<SiparisModel>>(api);
  }

  add(siparis:SiparisModel):Observable<ResponseModel>{
    let api = environment.apiURL;
    return this.httpClient.post<ResponseModel>(api,siparis);
  }

  delete(id:number):Observable<ResponseModel>{
    let api = environment.apiURL+id;
    return this.httpClient.delete<ResponseModel>(api);
  }

  update(siparis:SiparisModel):Observable<ResponseModel>{
    let api = environment.apiURL+siparis.id;
    return this.httpClient.put<ResponseModel>(api,siparis);
  }

}
