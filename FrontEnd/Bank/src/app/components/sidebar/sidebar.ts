import { Component, EventEmitter, Output} from '@angular/core';
import { RouterLink } from '@angular/router'; 

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class Sidebar {
@Output() hide_SideBar = new EventEmitter<boolean>();

currSideBarTile : number = 1;

changeTile(currSideBarTile : number)
{
  this.hide_SideBar.emit(true);
  this.currSideBarTile = currSideBarTile;
}


}
