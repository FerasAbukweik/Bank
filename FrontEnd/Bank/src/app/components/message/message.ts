import { Component, EventEmitter, Input, OnInit, Output, output } from '@angular/core';

@Component({
  selector: 'app-message',
  imports: [],
  templateUrl: './message.html',
  styleUrl: './message.css'
})
export class Message implements OnInit{

  @Input() message! : string;

  @Output() showMessage = new EventEmitter<boolean>();
  ngOnInit(): void {
    
  }

}
