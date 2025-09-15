import { Component } from '@angular/core';
import { NameGmail } from './components/name-gmail/name-gmail';
import { ChangePassword } from './components/change-password/change-password';

@Component({
  selector: 'app-profile-settings',
  imports: [NameGmail , ChangePassword],
  templateUrl: './profile-settings.html',
  styleUrl: './profile-settings.css'
})
export class ProfileSettings {

}
