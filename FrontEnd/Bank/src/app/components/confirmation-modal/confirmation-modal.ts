import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ModalConfirmationRetData } from '../interfaces/modal-confirmation';
import { modalReceivingData } from '../interfaces/modal-receiving-data';


@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.html',
  styleUrls: ['./confirmation-modal.css']
})
export class ConfirmationModal implements OnInit {

    currStatus : ModalConfirmationRetData = {
    isConfirmed : false,
    isCanceled : false,
    value : ""
  }

  @Input() toViewData!: modalReceivingData;

  @Output() toReturn = new EventEmitter<ModalConfirmationRetData>();

  ngOnInit(): void {
    
  }

  confirm()
  {
    this.currStatus.isConfirmed=true;
    this.toReturn.emit(this.currStatus);
  }

    cancel()
  {
    this.currStatus.isCanceled=true;
    this.toReturn.emit(this.currStatus);
  }
}
