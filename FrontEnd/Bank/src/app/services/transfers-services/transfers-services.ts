import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTransaction } from '../../interfaces/transfer/AddTransaction';

@Injectable({
  providedIn: 'root'
})
export class TransfersServices {
apiUrl : string = "https://localhost:44375/api/Transfer";

constructor(private _http : HttpClient){}

public getNumOfTransactions(userId : number){
let params = new HttpParams();
params = params.set("userId" , userId)
return this._http.get(this.apiUrl + "/getNumberOfTransfers" , {params} );
}

public getRecentActivities(userId : number){
  let params = new HttpParams()
  params = params.set("userId" , userId);
  return this._http.get(this.apiUrl + "/getRecentActivity" , {params});
}


public postAddTransfer(data: AddTransaction) {
  return this._http.post(this.apiUrl + "/add", {
    amount: data.amount,
    transactionType: data.transactionType,
    fromAccount_id: data.fromAccount_id ?? null,
    toAccount_id: data.toAccount_id ?? null,
    fromUserId: data.fromUserId ?? null,
    toUserId: data.toUserId ?? null
  });
}

public getTransactions(userId : number)
{
  let params = new HttpParams()
  params = params.set("userId" , userId);
  return this._http.get(this.apiUrl + "/getTransactions" , {params});
}
  
}
