import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddAccountData } from '../../interfaces/account/addAccountData';

@Injectable({
  providedIn: 'root'
})
export class AccountsServices {
  
apiUrl : string = "https://localhost:44375/api/Accounts";

  constructor(private _http : HttpClient){}


  public getAccountsMinorData(userId : number)
  {
    let params = new HttpParams();
    params = params.set("userId" , userId.toString());
    return this._http.get(this.apiUrl + "/getDashboardAccounts" , {params});
  }

  public getUserIdFromAccountId(accountId : number)
  {
    let params = new HttpParams();
    params = params.set("accountId" , accountId);
    return this._http.get(this.apiUrl + "/getUserIdFromAccountId" , {params});
  }

  public add(data : AddAccountData)
  {
    return this._http.post(this.apiUrl + "/add" , {
  "user_id": data.userId,
  "accountTypes_id": data.accountTypes_id
})
  }

  public delete(accountId : number)
  {
    let params = new HttpParams();
    params = params.set("accountId" , accountId);
    return this._http.delete(this.apiUrl + "/delete" , {params})
  }
}
