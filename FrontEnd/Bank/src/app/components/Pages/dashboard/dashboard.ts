import { Component } from '@angular/core';
import { TotalBalance } from './dashboard-components/total-balance/total-balance';
import { Transactions } from './dashboard-components/transactions/transactions';
import { RecentActivities } from './dashboard-components/recent-activities/recent-activities';
import { AccountsContainer } from './dashboard-components/accounts-container/accounts-container';

@Component({
  selector: 'app-dashboard',
  imports: [TotalBalance , Transactions,RecentActivities , AccountsContainer],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

}
