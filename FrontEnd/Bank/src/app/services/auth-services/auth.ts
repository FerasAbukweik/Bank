import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginData } from '../../interfaces/login/login-data';

@Injectable({
  providedIn: 'root'
})
export class Auth {
  
apiUrl : string = "https://localhost:44375/api/Auth";

constructor(private _http : HttpClient){}



  public login(data : LoginData)
  {
    let params = new HttpParams();
    params = params.set("userName" , data.userName);
    params = params.set("Password" , data.password);
    return this._http.get(this.apiUrl + "/login" , {params})
  }
}
