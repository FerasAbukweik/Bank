import { Component } from '@angular/core';
import { Lable } from '../../lable/lable';
import { FormGroup , FormControl , ReactiveFormsModule, Validators } from '@angular/forms';
import { Auth } from '../../../services/auth-services/auth';
import { LoginData } from '../../../interfaces/login/login-data';
import { Router } from '@angular/router';
import { Message } from '../../message/message';

@Component({
  selector: 'app-login',
  imports: [Lable , ReactiveFormsModule , Message],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  showReqiredUserName : boolean = false;
  showReqiredPassword : boolean = false;
  showMessage : boolean = false;
  message :string = "";

  
  inputData : FormGroup = new FormGroup(
    {
      userName : new FormControl("" , [Validators.required]) , 
      password : new FormControl("" , [Validators.required])
    }
  )

  constructor(private _auth : Auth , 
    private _router : Router
  ) {}

  login()
  {
    
    if (!this.inputData.valid){
  this.showReqiredUserName = this.inputData.get('userName')?.invalid ?? true;
  this.showReqiredPassword = this.inputData.get('password')?.invalid ?? true;
  return;
}

      this.showReqiredUserName = false;
      this.showReqiredPassword = false;
      
      let loginData : LoginData = {
        userName : this.inputData.value.userName,
        password : this.inputData.value.password
      };

      this._auth.login(loginData).subscribe({
        next : (ret : any) =>{
          localStorage.setItem("token" , ret.token);
          localStorage.setItem("roleName" , ret.roleName);
          localStorage.setItem("userId" , ret.userId.toString());
          this._router.navigate(['/dashBoard']);
        },
        error : (err)=>{
          this.message = err.error?.message ?? err.error ?? "Unexpected Error";
          this.showMessage = true;
        }
      })
  }

  navigateToSignUpPage()
  {
    this._router.navigate(['signup'])
  }
}
