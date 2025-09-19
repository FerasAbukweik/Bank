import { Component, OnInit } from '@angular/core';
import { NameGmail } from './components/name-gmail/name-gmail';
import { ChangePassword } from './components/change-password/change-password';
import { User } from '../../../interfaces/user/user';
import { UsersServices } from '../../../services/users-services/users-services';

@Component({
  selector: 'app-profile-settings',
  imports: [NameGmail , ChangePassword],
  templateUrl: './profile-settings.html',
  styleUrl: './profile-settings.css'
})
export class ProfileSettings implements OnInit {

  user : User | undefined;

  constructor(private _usersServices : UsersServices){}

ngOnInit(): void {
  this.updateUser();
}

updateUser(){
this._usersServices.getUserById(+localStorage.getItem("userId")!).subscribe({
  next : (ret : any)=>{
    let tempUser : User = {
      id : ret.id,
      userName : ret.userName,
      hashedPassword : ret.hashedPassword,
      email : ret.email,
      phone : ret.phone,
      createdAt : ret.createdAt,
      BankRole_id : ret.BankRole_id
    }

    this.user = tempUser;
  },
  error : (err)=>{
    console.log(err.error?.message ?? err.error ?? "Unexpected Error");
  }
})
}

}
