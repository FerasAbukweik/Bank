import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountTypesServices {
  ApiUrl : string = "https://localhost:44375/api/AccountTypes";

  constructor(private _http : HttpClient){}

  public getAll()
  {
    let params = new HttpParams();
    return this._http.get(this.ApiUrl + "/getAll" , {params});
  }
}
