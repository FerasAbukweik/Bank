import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountsServices {
  
  constructor(private _http : HttpClient){}

  public getTotalBalance(userId : number)
  {
    let params = new HttpParams();
    params = params.set("id" , userId.toString());
    return this._http.get("api" , {params});
  }
}
