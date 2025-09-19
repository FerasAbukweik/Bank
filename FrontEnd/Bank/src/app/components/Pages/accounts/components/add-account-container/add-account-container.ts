import { Component, EventEmitter, OnInit, Output, output } from '@angular/core';
import { fromAddAccountContainerToFather } from '../interface/fromAddAccountContainerToFather';
import { FormsModule } from '@angular/forms';
import { AccountType } from '../../../../../interfaces/account-type/accountType';
import { AccountTypesServices } from '../../../../../services/account-types-services/account-types-services';

@Component({
  selector: 'app-add-account-container',
  imports: [FormsModule],
  templateUrl: './add-account-container.html',
  styleUrl: './add-account-container.css'
})
export class AddAccountContainer implements OnInit {
  accountTypes : AccountType[] = []; 
  @Output() retData = new EventEmitter<fromAddAccountContainerToFather>();
  option : number = 1;

  constructor(private _accountType : AccountTypesServices){}

  ngOnInit(): void {
    this.updateAccountTypes();
  }

  updateAccountTypes()
  {
    this._accountType.getAll().subscribe({
      next : (ret : any)=>{
        this.accountTypes = [];
        ret.forEach((accountType : any) => {
          let temp : AccountType = {
          id : accountType.id,
          type : accountType.type
        }

        this.accountTypes.push(temp);
        });
      },
      error : (err)=>{
        console.log(err.error?.message ?? err.error ?? "Unexpected Error");
      }
    })
  }

  sendData(isSaved : boolean)
  {
    let tempData : fromAddAccountContainerToFather = {
      isSaved : isSaved,
      typeId : this.option
    }

    this.retData.emit(tempData);
  }
}
