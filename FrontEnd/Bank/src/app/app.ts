import { Component, ElementRef, signal, ViewChild } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { Sidebar } from './components/sidebar/sidebar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App  {
  protected readonly title = signal('Bank');
  sideBarState : boolean = window.innerWidth <= 600;

  constructor(private router : Router) {}

showSideBar(): boolean {
  let currUrl : String = this.router.url;
  return currUrl !== "/login" && currUrl != "/signup";
}

  toggleSideBar() {
    this.sideBarState = !this.sideBarState;
  }
}
