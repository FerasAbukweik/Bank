import { Component, OnInit } from '@angular/core';
import { dashboardAccounts } from "../../../../../interfaces/accounts/dashboardAccounts";
import { AccountsServices } from '../../../../../services/accounts-services/accounts-services';

@Component({
  selector: 'app-accounts-container',
  imports: [],
  templateUrl: './accounts-container.html',
  styleUrl: './accounts-container.css'
})
export class AccountsContainer implements OnInit {
dashboard_Accounts :  dashboardAccounts[] = [];

constructor(private _accountsService : AccountsServices) {}

ngOnInit(): void {
  this.updateDashboard_Accounts(2);
}

updateDashboard_Accounts(userId : number){
this._accountsService.getDashboardAccounts(userId).subscribe({
  next : (ret : any) =>{
    this.dashboard_Accounts = [];

    ret.forEach((account : any) =>{
      let toAdd : dashboardAccounts = {
        type : account.type,
        balance : account.account
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
