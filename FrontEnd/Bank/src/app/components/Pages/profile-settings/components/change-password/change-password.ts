import { Component } from '@angular/core';
import { ModalConfirmationRetData } from '../../../../interfaces/modal-confirmation';
import { ConfirmationModal } from "../../../../confirmation-modal/confirmation-modal";
import { modalReceivingData } from '../../../../interfaces/modal-receiving-data';
import { UsersServices } from '../../../../../services/users-services/users-services';
import { UpdateUser } from '../../../../../interfaces/user/update-user';

@Component({
  selector: 'app-change-password',
  imports: [ConfirmationModal],
  templateUrl: './change-password.html',
  styleUrl: './change-password.css'
})
export class ChangePassword {
  showModal : boolean = false;
  retrivedData : ModalConfirmationRetData = {
    isCanceled : false,
    isConfirmed : false,
    value : ""
  }

  toViewInModal : modalReceivingData = {
    title : "New Password",
    subTitle : ""
  }

  constructor(private _usersServices : UsersServices) {}

  closeModal(){
    this.showModal = false;
  }

  manageRetrivedData(ret : ModalConfirmationRetData)
  {
    if(ret.isCanceled)
    {
      this.closeModal();
      return;
    }
    if(ret.isConfirmed)
    {
      let toUpdate : UpdateUser = {
        id : +localStorage.getItem("userId")!,
        userName : null,
        password : ret.value,
        email : null,
        phone : null
      }

      this._usersServices.updateUser(toUpdate).subscribe({
        error : (err)=>{
          console.log(err.error?.message ?? err.error ?? "Unexpected Error");
        }
      })

      this.closeModal();
    }
  }

  showConfirmationModal(){
    this.showModal = true;
  }
}
