import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {InputModel} from '../../../models/InputModel';

@Component({
  selector: 'app-input-control',
  templateUrl: './input-control.component.html',
  styleUrls: ['./input-control.component.css']
})
export class InputControlComponent implements OnInit {
  @Input() inputModel : InputModel;
  @Output() readEvent = new EventEmitter();
  readInput(event){
    this.inputModel.value = event.target.value;
    this.readEvent.emit(event);
  }
  
  constructor() { }

  ngOnInit(): void {}

}
