import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ModalInterface } from '../account-container/interfaces/modal-interface';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';
import { AddTransaction } from '../../../../../interfaces/transfers/AddTransaction';
import { transactionTypesEnums } from '../../../../../enums/transfers';
import { Message_Modal } from '../account-container/interfaces/message-interface';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.html',
  styleUrls: ['./confirmation-modal.css']
})
export class ConfirmationModal implements OnInit {

inputValue : number = 0;
tempMessage_Modal : Message_Modal = {
    showMessage : false,
    showModal : true,
    message : ""
  }


  @Input() modalData! : ModalInterface;
  @Output() message_modal = new EventEmitter<Message_Modal>();


  constructor(private _transfersServices : TransfersServices){}

  ngOnInit(): void {
    
  }

closeModal(){
  this.tempMessage_Modal.showModal = false;
  this.message_modal.emit(this.tempMessage_Modal);
}

confirmAction(){
  if(this.inputValue <= 0) {this.tempMessage_Modal.message = "Type Valid Value";
    this.tempMessage_Modal.showMessage = true;
    this.closeModal();
    this.message_modal.emit(this.tempMessage_Modal);
     return;}
  
  if(this.modalData.title === 'Withdraw')
  {
    if(this.modalData.account.balance < this.inputValue) {this.tempMessage_Modal.message = "Not Enough Balance";
      this.tempMessage_Modal.showMessage = true;
      this.closeModal();
      this.message_modal.emit(this.tempMessage_Modal);
       return;}
    
    let dataToSend : AddTransaction = {
    amount : this.inputValue,
    transactionType : +transactionTypesEnums.Withdrawal,
    fromAccount_id : this.modalData.account.id,
    toAccount_id : null,
    fromUserId : 2,
    toUserId : null
  }

  this._transfersServices.postAddTransfer(dataToSend).subscribe({
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
}
if(this.modalData.title === 'Deposit')
{
    let dataToSend : AddTransaction = {
    amount : this.inputValue,
    transactionType : +transactionTypesEnums.Deposit,
    fromAccount_id : null,
    toAccount_id : this.modalData.account.id,
    fromUserId : null,
    toUserId : 2
  }

  this._transfersServices.postAddTransfer(dataToSend).subscribe({
    error : (err)=>{
      console.log(err.error?.message ?? err.error ?? "Unexpected Error");
    }
  })
}

  this.closeModal();
this.message_modal.emit(this.tempMessage_Modal);
  window.location.reload();
}


}
