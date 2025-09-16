import { Component, ElementRef, ViewChild, viewChild } from '@angular/core';
import { Sidebar } from '../../sidebar';

@Component({
  selector: 'app-menu-icon',
  imports: [],
  templateUrl: './menu-icon.html',
  styleUrl: './menu-icon.css'
})
export class MenuIcon {
  @ViewChild('sideBar') sideBar!: ElementRef;

  toggleSideBar() {
    const el = this.sideBar.nativeElement as HTMLElement;
    if (getComputedStyle(el).display === 'none') {
      el.style.display = 'flex !important';
    } else {
      el.style.display = 'none !important';
    }
  }
}
