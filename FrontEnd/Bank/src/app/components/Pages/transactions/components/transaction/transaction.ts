import { Component, Input, OnInit } from '@angular/core';
import { TransactionModel } from '../../../../../interfaces/transfer/TransferMinorData';
import { DatePipe } from '@angular/common';
import { transactionTypesEnums } from '../../../../../enums/transfers';

@Component({
  selector: 'app-transaction',
  imports: [DatePipe],
  templateUrl: './transaction.html',
  styleUrl: './transaction.css'
})
export class Transaction implements OnInit{

  isRed! : boolean;
  isGreen! : boolean;
  type! : string;

  @Input() transaction_data! : TransactionModel;


  ngOnInit(): void {
   this.isRed = transactionTypesEnums.Withdraw == this.transaction_data.TransactionType;
   this.isGreen = transactionTypesEnums.Deposit == this.transaction_data.TransactionType;
   
   this.type = this.transaction_data.TransactionType == transactionTypesEnums.Withdraw ? 'Withdraw'  : 
   this.transaction_data.TransactionType == transactionTypesEnums.Deposit ? 'Deposit' :
   this.transaction_data.TransactionType == transactionTypesEnums.Send ? 'send' : 'Not Found';
  }
}
