import { Component } from '@angular/core';
import { AccountContainer } from './components/account-container/account-container';

@Component({
  selector: 'app-accounts',
  imports: [AccountContainer],
  templateUrl: './accounts.html',
  styleUrl: './accounts.css'
})
export class Accounts {

}
