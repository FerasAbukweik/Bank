import { Component, EventEmitter, OnInit, Output} from '@angular/core';
import { Router, RouterLink } from '@angular/router'; 
import { Lable } from '../lable/lable';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink  , Lable],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class Sidebar implements OnInit{
@Output() hide_SideBar = new EventEmitter<boolean>();

currSideBarTile : number = 1;

constructor(private _router : Router) {}

ngOnInit(): void {
  let stored = localStorage.getItem("currSideBarTile");
  if(stored != null || stored != '0')
  {
    this.currSideBarTile = +stored!;
  }
}

changeTile(currSideBarTile : number)
{
  this.hide_SideBar.emit(
    window.innerWidth <=600
  );
  this.currSideBarTile = currSideBarTile;
  localStorage.setItem("currSideBarTile" , this.currSideBarTile.toString());
}

logout()
{
  localStorage.removeItem("token");
  localStorage.removeItem("roleName");
  localStorage.removeItem("userId");
  this._router.navigate(["/login"]);
  this.currSideBarTile = 1;
  this.hide_SideBar.emit(true);
}

}
