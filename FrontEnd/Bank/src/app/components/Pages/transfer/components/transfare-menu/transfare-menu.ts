import { Component, OnInit } from '@angular/core';
import { accountsMinorData } from '../../../../../interfaces/accounts/accountsMinorData';
import { AccountsServices } from '../../../../../services/accounts-services/accounts-services';
import { FormGroup , FormControl , ReactiveFormsModule, Validators } from '@angular/forms';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';
import { AddTransaction } from '../../../../../interfaces/transfers/AddTransaction';
import { transactionTypesEnums } from '../../../../../enums/transfers';
import { Message } from "../../../../message/message";

@Component({
  selector: 'app-transfare-menu',
  imports: [ReactiveFormsModule, Message],
  templateUrl: './transfare-menu.html',
  styleUrl: './transfare-menu.css'
})
export class TransfareMenu implements OnInit{

  accounts : accountsMinorData[] = [];
  showMessage : boolean = false;
  message : string = ""

  transferData : FormGroup = new FormGroup({
    from : new FormControl(0 , [Validators.required]),
    to : new FormControl(null , [Validators.required]),
    amount : new FormControl(null , [Validators.required])
  })

  constructor(private _accountsServices : AccountsServices , 
    private _transferServices : TransfersServices
  ){}

  ngOnInit(): void {
    this.updateAccounts(2);
  }
updateAccounts(userId : number){
  this._accountsServices.getAccountsMinorData(userId).subscribe({
    next : (ret : any)=>{
      this.accounts = [];
      ret.forEach((account : any) => {
              let tempAccount : accountsMinorData = {
                id : account.id,
                type : account.type,
                balance : account.balance
              };
              this.accounts.push(tempAccount);
      });
    },
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
}



AddTransform(){
if(this.accounts[this.transferData.value.from].balance < this.transferData.value.amount)
{
  this.message = "Not Enough Balance";
  this.showMessage = true;
  return;
}

if(this.transferData.value.amount <=0)
{
    this.message = "Use Valid Value";
  this.showMessage = true;
  return;
}

let currAccountIndex : number = this.transferData.value.from;
let toUserId : number | null = null;
let toAccountId : number = this.transferData.value.to;

this._accountsServices.getUserIdFromAccountId(toAccountId).subscribe({
  next : (ret : any)=> {
    let toUserId = ret;

    let toAdd_Transfer : AddTransaction = {
      amount : this.transferData.value.amount,
      transactionType : transactionTypesEnums.send,
      fromAccount_id : this.accounts[currAccountIndex].id,
      toAccount_id : toAccountId,
      fromUserId : 2,
      toUserId : toUserId
    };

    this._transferServices.postAddTransfer(toAdd_Transfer).subscribe({
      next : ()=> {window.location.reload()},
      error : (err)=> {
        this.message = err.error?.message ?? err.error ?? "Unexpected Error";
        this.showMessage = true;
      }
    });

  },
  error : (err)=> {
    this.message = err.error?.message ?? err.error ?? "Unexpected Error";
    this.showMessage = true;
  }
})
}
}
