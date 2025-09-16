import { Component , Input, OnInit } from '@angular/core';
import { AccountsServices } from '../../../../../services/accounts-services/accounts-services';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';
import { RecentActivities } from '../recent-activities/recent-activities';
import { RecentActivitie } from '../../../../../interfaces/transfers/recentActivities';

@Component({
  selector: 'app-total-balance',
  imports: [],
  templateUrl: './total-balance.html',
  styleUrl: './total-balance.css'
})
export class TotalBalance implements OnInit {
  totalBalance: number | undefined;
  @Input() lastTransfer : RecentActivitie |undefined;


  constructor(private _accountService: AccountsServices,
  ) {}

  ngOnInit(): void {
    this.getTotalBalance(2);
  }

  getTotalBalance(userId: number) {
    this._accountService.getTotalBalance(userId).subscribe({
      next : (ret : any)=>{
        this.totalBalance = ret;
      },
      error : (err)=>{
        console.log(err.error?.message ?? err.error ?? "Unexpected Error");
      }
    });
  }
}
