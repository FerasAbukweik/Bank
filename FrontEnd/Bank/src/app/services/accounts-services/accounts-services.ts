import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsServices {
  
apiUrl : string = "https://localhost:44375/api/Accounts";

  constructor(private _http : HttpClient){}

  public getTotalBalance(userId : number)
  {
    let params = new HttpParams();
    params = params.set("id" , userId.toString());
    return this._http.get(this.apiUrl + "/getTotalBalance" , {params});
  }

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
}
