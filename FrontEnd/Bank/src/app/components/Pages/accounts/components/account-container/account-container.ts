import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { accountsMinorData } from '../../../../../interfaces/accounts/accountsMinorData';
import { ConfirmationModal } from '../confirmation-modal/confirmation-modal';
import { ModalInterface } from './interfaces/modal-interface';
import { Title } from '@angular/platform-browser';
import { Message } from '../../../../message/message';
import { Message_Modal } from './interfaces/message-interface';

@Component({
  selector: 'app-account-container',
  imports: [ConfirmationModal , Message],
  templateUrl: './account-container.html',
  styleUrl: './account-container.css'
})
export class AccountContainer implements OnInit {

  messageModal : Message_Modal = {
    showMessage : false,
    showModal : false ,
    message : ""
  };
  ModalData! : ModalInterface;

  @Input() account!: accountsMinorData;

  ngOnInit(): void {
    this.ModalData = {
      title : "",
      account : this.account
    }
  }

  tempAccount! : accountsMinorData;



 


  openDialog(title : string) {
    this.ModalData.title = title;
    this.messageModal.showModal = true;
  }
}
