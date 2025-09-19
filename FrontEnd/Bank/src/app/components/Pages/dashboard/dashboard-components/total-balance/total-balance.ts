import { Component , Input, OnInit } from '@angular/core';
import { RecentActivitie } from '../../../../../interfaces/transfer/recentActivities';
import { UsersServices } from '../../../../../services/users-services/users-services';

@Component({
  selector: 'app-total-balance',
  imports: [],
  templateUrl: './total-balance.html',
  styleUrl: './total-balance.css'
})
export class TotalBalance implements OnInit {
  totalBalance: number | undefined;
  @Input() lastTransfer : RecentActivitie |undefined;


  constructor(private _usersServices: UsersServices,
  ) {}

  ngOnInit(): void {
    this.getTotalBalance(+localStorage.getItem("userId")!);
  }

  getTotalBalance(userId: number) {
    this._usersServices.getTotalBalance(userId).subscribe({
      next : (ret : any)=>{
        this.totalBalance = ret;
      },
      error : (err)=>{
        console.log(err.error?.message ?? err.error ?? "Unexpected Error");
      }
    });
  }
}
