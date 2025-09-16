import { Component, OnInit } from '@angular/core';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';

@Component({
  selector: 'app-transactions',
  imports: [],
  templateUrl: './transactions.html',
  styleUrl: './transactions.css'
})
export class Transactions implements OnInit{
  numOfTransactions : number | undefined;

  constructor(private _transferServices : TransfersServices){}

  ngOnInit(): void {
    this.updateNumOfTransactions(2)
  }

  updateNumOfTransactions(userId : number)
  {
    this._transferServices.getNumOfTransactions(userId).subscribe({
      next:(ret:any)=>{
        this.numOfTransactions = ret;
      },
      error:(err)=>{
        console.log(err.error?.message ?? err.error ?? "Unexpected Error");
      }
    })
  }

}
