import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-name-gmail',
  imports: [],
  templateUrl: './name-gmail.html',
  styleUrl: './name-gmail.css'
})
export class NameGmail implements OnInit {
@Input() userName! :string;
@Input() email! : string;

ngOnInit(): void {
  
}
}
