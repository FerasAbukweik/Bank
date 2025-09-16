import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransfersServices {
apiUrl : string = "https://localhost:44375/api/Transfer";

constructor(private _http : HttpClient){}

public getNumOfTransactions(userId : number){
let params = new HttpParams();
params = params.set("userId" , userId.toString())
return this._http.get(this.apiUrl + "/getNumberOfTransfers" , {params} );
}

public getRecentActivities(userId : number){
  let params = new HttpParams()
  params = params.set("userId" , userId.toString());
  return this._http.get(this.apiUrl + "/getRecentActivity" , {params})
}

  
}
