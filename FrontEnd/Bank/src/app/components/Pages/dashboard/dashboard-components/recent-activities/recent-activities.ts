import { Component, Input } from '@angular/core';
import { TransfersServices } from '../../../../../services/transfers-services/transfers-services';
import { RecentActivitie } from '../../../../../interfaces/transfer/recentActivities';

@Component({
  selector: 'app-recent-activities',
  imports: [],
  templateUrl: './recent-activities.html',
  styleUrl: './recent-activities.css'
})
export class RecentActivities {
 @Input() recentActivities : RecentActivitie[] | undefined;
}
