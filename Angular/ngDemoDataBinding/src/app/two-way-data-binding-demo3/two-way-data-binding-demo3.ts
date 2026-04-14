import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-two-way-data-binding-demo3',
  imports: [],
  templateUrl: './two-way-data-binding-demo3.html',
  styleUrl: './two-way-data-binding-demo3.css',
})
export class TwoWayDataBindingDemo3 {
  @Input() count: number = 0;
  @Output() countChange: EventEmitter<number>=new EventEmitter<number>();

  increment(){
    this.count++;
    this.countChange.emit(this.count);
  }
}
