import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule ,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../../services/auth-services/auth';
import { LoginData } from '../../../interfaces/login/login-data';
import { Message } from '../../message/message';
import { Lable } from '../../lable/lable';
import { AddUser } from '../../../interfaces/user/add-user';
import { UsersServices } from '../../../services/users-services/users-services';

@Component({
  selector: 'app-signup',
  imports: [Message , Lable , ReactiveFormsModule],
  templateUrl: './signup.html',
  styleUrl: './signup.css'
})
export class Signup {

  showReqiredUserName : boolean = false;
  showReqiredEmail : boolean = false;
  showReqiredPhone : boolean = false;
  showReqiredPassword : boolean = false;
  showWrongEmail : boolean = false;
  showWrongPhoneNumber : boolean = false;
  showMessage : boolean = false;
  message :string = "";

  
  inputData : FormGroup = new FormGroup(
    {
      userName : new FormControl("" , [Validators.required]) , 
      email : new FormControl("" , [Validators.required , Validators.email]),
      phone : new FormControl("" , [Validators.required , Validators.minLength(10) , Validators.maxLength(13)]),
      password : new FormControl("" , [Validators.required])
    }
  )

  constructor(private _auth : Auth , 
    private _router : Router,
    private _userServices : UsersServices
  ) {}

  signup()
  {
    
  if (!this.inputData.valid){
    this.showReqiredUserName = this.inputData.get('userName')?.invalid ?? true;
    this.showReqiredPassword = this.inputData.get('password')?.invalid ?? true;

    let emailInput = this.inputData.get('email');
    if(emailInput?.invalid ?? false)
    {
      if(emailInput?.errors?.['required'] ?? false)
      {
        this.showReqiredEmail = true;
      }
      else
      {
        this.showReqiredEmail = false;
      }
      if(emailInput?.errors?.['email'] ?? false)
      {
        this.showWrongEmail = true;
      }
      else
      {
        this.showWrongEmail = false;
      }
    }
    else
    {
      this.showReqiredEmail = false;
      this.showWrongEmail = false;
    }

    let phoneInput = this.inputData.get('phone');
    if(phoneInput?.invalid ?? false)
    {
      if(phoneInput?.errors?.['required'])
      {
        this.showReqiredPhone = true;
      }
      if((phoneInput?.errors?.['minlength'] ?? false) || (phoneInput?.errors?.['maxlength'] ?? false))
      {
        this.showWrongPhoneNumber = true;
      }
    }
    else
    {
      this.showReqiredPhone = false;
      this.showWrongPhoneNumber = false;
    }

      return;
  }
  this.showWrongPhoneNumber = false;
  this.showWrongEmail = false;
  this.showReqiredPassword = false;
  this.showReqiredPhone = false;
  this.showReqiredEmail = false;
  this.showReqiredUserName = false;


      
      let signupData : AddUser = {
        userName : this.inputData.value.userName,
        password : this.inputData.value.password,
        email : this.inputData.value.email,
        phone : this.inputData.value.phone
      };

      this._userServices.addUser(signupData).subscribe({
        next : (ret : any) =>{
          this._router.navigate(['/login']);
        },
        error : (err)=>{
          this.message = err.error?.message ?? err.error ?? "Unexpected Error";
          this.showMessage = true;
        }
      })
}

  navigateToLogin()
  {
    this._router.navigate(['login']);
  }

}


