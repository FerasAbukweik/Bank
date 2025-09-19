import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ButtonData } from '../interface/button-data';

@Component({
  selector: 'app-button',
  imports: [],
  templateUrl: './button.html',
  styleUrl: './button.css'
})
export class Button {
@Output() isClicked = new EventEmitter<boolean>();
@Input() buttonData! : ButtonData;
}
