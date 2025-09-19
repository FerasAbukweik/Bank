import { Component, OnInit } from '@angular/core';
import { accountsMinorData } from "../../../../../interfaces/account/accountsMinorData";
import { AccountsServices } from '../../../../../services/accounts-services/accounts-services';

@Component({
  selector: 'app-accounts-container',
  imports: [],
  templateUrl: './accounts-container.html',
  styleUrl: './accounts-container.css'
})
export class AccountsContainer implements OnInit {
dashboard_Accounts :  accountsMinorData[] = [];

constructor(private _accountsService : AccountsServices) {}

ngOnInit(): void {
  this.updateDashboard_Accounts(+localStorage.getItem("userId")!);
}

updateDashboard_Accounts(userId : number){
this._accountsService.getAccountsMinorData(userId).subscribe({
  next : (ret : any) =>{
    this.dashboard_Accounts = [];

    ret.forEach((account : any) =>{
      let toAdd : accountsMinorData = {
        id : account.id,
        type : account.type,
        balance : account.balance
      }

        this.dashboard_Accounts.push(toAdd);
    })
  },
  error : (err)=>{
    console.log(err.error?.message ?? err.error ?? "Unexpected Error");
  }
})
}
}
