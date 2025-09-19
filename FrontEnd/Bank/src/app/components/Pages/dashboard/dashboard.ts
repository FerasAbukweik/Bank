import { Component, EventEmitter, OnInit, Output, output } from '@angular/core';
import { TotalBalance } from './dashboard-components/total-balance/total-balance';
import { Transactions } from './dashboard-components/transactions/transactions';
import { AccountsContainer } from './dashboard-components/accounts-container/accounts-container';
import { TransfersServices } from '../../../services/transfers-services/transfers-services';
import { RecentActivitie } from '../../../interfaces/transfer/recentActivities';
import { RecentActivities } from './dashboard-components/recent-activities/recent-activities';

@Component({
  selector: 'app-dashboard',
  imports: [TotalBalance , Transactions, RecentActivities , AccountsContainer],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {
allRecentActivities : RecentActivitie[] = [];


constructor(private _transfersServices : TransfersServices){}

ngOnInit(): void {
  this.updateRecentActivities(+localStorage.getItem("userId")!);
}

private updateRecentActivities(userId : number){
this._transfersServices.getRecentActivities(userId).subscribe({
  next : (ret : any) =>{
    this.allRecentActivities = [];

    ret.forEach((ret_activity : any) => {
      let activity : RecentActivitie = {
      id : ret_activity.id,
      amount : ret_activity.amount,
      isDeposit : ret_activity.isDeposit
    }
    this.allRecentActivities.push(activity);
    });
  },
  error : (err)=>{
    console.log(err.error?.message ?? err.error ?? "Unexpected Error");
  }
})
}
}
