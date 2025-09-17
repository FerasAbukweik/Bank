import { Component, EventEmitter } from '@angular/core';
import { AccountContainer } from './components/account-container/account-container';
import { accountsMinorData } from '../../../interfaces/accounts/accountsMinorData';
import { AccountsServices } from '../../../services/accounts-services/accounts-services';
import { TransfersServices } from '../../../services/transfers-services/transfers-services';

@Component({
  selector: 'app-accounts',
  imports: [AccountContainer ],
  templateUrl: './accounts.html',
  styleUrl: './accounts.css'
})
export class Accounts {

accounts : accountsMinorData[] = [];



constructor(private _accountsServices : AccountsServices,
  private _transfersServices : TransfersServices
){}
ngOnInit(): void {
  this.updateaAcounts(2);
}

updateaAcounts(userId : number){
this._accountsServices.getAccountsMinorData(userId).subscribe({
  next : (ret : any) =>{
    this.accounts = [];

    ret.forEach((account : any) =>{
      let toAdd : accountsMinorData = {
        id : account.id,
        type : account.type,
        balance : account.balance
      }

        this.accounts.push(toAdd);
    })
  },
  error : (err)=>{
    console.log(err.error?.message ?? err.error ?? "Unexpected Error");
  }
})
}
}
