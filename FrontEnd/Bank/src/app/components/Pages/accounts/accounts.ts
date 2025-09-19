import { Component, EventEmitter } from '@angular/core';
import { AccountContainer } from './components/account-container/account-container';
import { accountsMinorData } from '../../../interfaces/account/accountsMinorData';
import { AccountsServices } from '../../../services/accounts-services/accounts-services';
import { TransfersServices } from '../../../services/transfers-services/transfers-services';
import { Button } from './components/normal-button/button';
import { AddAccountContainer } from './components/add-account-container/add-account-container';
import { AddAccountData } from '../../../interfaces/account/addAccountData'; 
import { fromAddAccountContainerToFather } from './components/interface/fromAddAccountContainerToFather';
import { ButtonData } from './components/interface/button-data';

@Component({
  selector: 'app-accounts',
  imports: [AccountContainer, Button, AddAccountContainer, Button],
  templateUrl: './accounts.html',
  styleUrl: './accounts.css'
})
export class Accounts {

accounts : accountsMinorData[] = [];
showAddAccount : boolean = false;
buttonData : ButtonData = {
  text : "+ Add Account",
  color : "#2368B9"
}



constructor(private _accountsServices : AccountsServices,
  private _transfersServices : TransfersServices
){}
ngOnInit(): void {
  this.updateaAcounts(+localStorage.getItem("userId")!);
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

closeAddAccount()
{
  this.showAddAccount = false;
}

manageAddAccount(ret : fromAddAccountContainerToFather)
{
  if(!ret.isSaved)
  {
    this.closeAddAccount();
    return;
  }

  let toAddAccount : AddAccountData = {
    userId : +localStorage.getItem("userId")!,
    accountTypes_id : ret.typeId
  }

  this._accountsServices.add(toAddAccount).subscribe({
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
  this.closeAddAccount();
  window.location.reload();
}

}
