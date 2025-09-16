import { Component, ElementRef, signal, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from './components/sidebar/sidebar';
import { Dashboard } from './components/Pages/dashboard/dashboard';
import { Accounts } from './components/Pages/accounts/accounts';
import { Transfer } from './components/Pages/transfer/transfer';
import { Transactions } from './components/Pages/transactions/transactions';
import { ProfileSettings } from './components/Pages/profile-settings/profile-settings';
import { MenuIcon } from "./components/sidebar/components/menu-icon/menu-icon";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, Dashboard, Accounts, Transfer, Transactions, ProfileSettings, MenuIcon],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Bank');
  sideBarState : boolean = false;

  toggleSideBar() {
    this.sideBarState = !this.sideBarState;
  }
}
