import { Component, OnInit } from '@angular/core';
import { Transaction } from './components/transaction/transaction';
import { TransfersServices } from '../../../services/transfers-services/transfers-services';
import { TransactionModel } from '../../../interfaces/transfer/TransferMinorData';

@Component({
  selector: 'app-transactions',
  imports: [Transaction],
  templateUrl: './transactions.html',
  styleUrl: './transactions.css'
})
export class Transactions implements OnInit {

  transactions : TransactionModel[] = [];

  constructor(private _transferServices : TransfersServices){}


ngOnInit(): void {
  this.updateTransactions();
}

updateTransactions(){
  this._transferServices.getTransactions(+localStorage.getItem("userId")!).subscribe({
    next : (ret : any)=>{
      this.transactions = [];

      ret.forEach((transaction : any) =>{
        let temp : TransactionModel = {
          id : transaction.id,
          amount : transaction.amount,
          createdAt : transaction.createdAt,
          TransactionType : transaction.transactionType
        }

        this.transactions.push(temp);
      })
    }
  })
}

}
