import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UpdateUser } from '../../interfaces/user/update-user';
import { AddUser } from '../../interfaces/user/add-user';

@Injectable({
  providedIn: 'root'
})
export class UsersServices {

  apiUrl : string = "https://localhost:44375/api/Users";

  constructor(private _http : HttpClient) {}

    public getTotalBalance(userId : number)
  {
    let params = new HttpParams();
    params = params.set("userId" , userId.toString());
    return this._http.get(this.apiUrl + "/getTotalBalance" , {params});
  }

  public getUserById(userId : number)
  {
    let params = new HttpParams();
    params = params.set("userId" , userId)
    return this._http.get(this.apiUrl + "/getUserById" , {params});
  }

  public updateUser(data : UpdateUser)
  {
    return this._http.put(this.apiUrl + "/update" , 
  {
  "id": data.id ?? null ,
  "userName": data.userName ?? null,
  "password": data.password ?? null ,
  "email": data.email ?? null,
  "phone": data.phone ?? null
});
  }

  public addUser(data : AddUser)
  {
    return this._http.post(this.apiUrl + "/add" , {
  "userName": data.userName,
  "password": data.password,
  "email": data.email,
  "phone": data.phone
})
  }
}
