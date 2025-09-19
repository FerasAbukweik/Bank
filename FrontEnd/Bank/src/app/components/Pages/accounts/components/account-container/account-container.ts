import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { accountsMinorData } from '../../../../../interfaces/account/accountsMinorData';
import { ConfirmationModal } from '../../../../confirmation-modal/confirmation-modal'; 
import { Message } from '../../../../message/message';
import { ModalConfirmationRetData } from '../../../../interfaces/modal-confirmation';
import { modalReceivingData } from '../../../../interfaces/modal-receiving-data';
import { AddTransaction } from '../../../../../interfaces/transfer/AddTransaction';
import { transactionTypesEnums } from '../../../../../enums/transfers';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';
import { Button } from '../normal-button/button';
import { ButtonData } from '../interface/button-data';
import { AccountsServices } from '../../../../../services/accounts-services/accounts-services';


@Component({
  selector: 'app-account-container',
  imports: [ConfirmationModal , Message ,Button],
  templateUrl: './account-container.html',
  styleUrl: './account-container.css'
})
export class AccountContainer implements OnInit {

  showModal : boolean = false;
  showMessage : boolean = false;
  message! : string;
  type! : string;

  buttonData : ButtonData = {
  text : "remove",
  color : "#eb2c2cff"
}



  modalState : ModalConfirmationRetData = {
    isCanceled : false,
    isConfirmed : false,
    value : ""
  }

  toViewData : modalReceivingData = {
    title : "",
    subTitle : ""
  }

  @Input() account!: accountsMinorData;

  ngOnInit(): void {

  }

  constructor(private _transfersServices : TransfersServices , 
    private _accountsServices : AccountsServices
  ){}

  openModal(type : string)
  {
    this.type = type;
    this.toViewData = {
      title : type,
      subTitle : "Amount"
    }
    this.showModal = true;
  }

  closeModal()
  {
    this.showModal = false;
  }

  manageToReturn(receivedStatus : ModalConfirmationRetData){
    if(receivedStatus.isCanceled)
    {
      this.closeModal();
      return;
    }
    if(receivedStatus.isConfirmed)
    {
      if(+receivedStatus.value <= 0) {this.message = "Type Valid Value";
    this.showMessage = true;
    this.closeModal();
     return;}
  
  if(this.type === 'Withdraw')
  {
    if(this.account.balance < +receivedStatus.value)
      {
       this.message = "Not Enough Balance";
       this.showMessage = true;
       this.closeModal();
       return;
      }
    
    let dataToSend : AddTransaction = {
    amount : +receivedStatus.value,
    transactionType : +transactionTypesEnums.Withdraw,
    fromAccount_id : this.account.id,
    toAccount_id : null,
    fromUserId : +localStorage.getItem("userId")!,
    toUserId : null
  }

  this._transfersServices.postAddTransfer(dataToSend).subscribe({
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
}
if(this.type === 'Deposit')
{
    let dataToSend : AddTransaction = {
    amount : +receivedStatus.value,
    transactionType : +transactionTypesEnums.Deposit,
    fromAccount_id : null,
    toAccount_id : this.account.id,
    fromUserId : null,
    toUserId : +localStorage.getItem("userId")!
  }

  this._transfersServices.postAddTransfer(dataToSend).subscribe({
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
}

  this.closeModal();
  window.location.reload();
    }
  }


  removeAccount()
  {
    this._accountsServices.delete(this.account.id).subscribe({
      error : (err)=>{
        console.log(err.error?.message ?? err.error ?? "Unexpected Error")
      }
    })

    window.location.reload();
  }
}
