import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from './components/sidebar/sidebar';
import { Dashboard } from './components/Pages/dashboard/dashboard';
import { Accounts } from './components/Pages/accounts/accounts';
import { Transfer } from './components/Pages/transfer/transfer';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet , Sidebar , Dashboard ,Accounts , Transfer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Bank');
}
