import { Component } from '@angular/core';

@Component({
  selector: 'app-two-way-data-binding-demo',
  imports: [],
  templateUrl: './two-way-data-binding-demo.html',
  styleUrl: './two-way-data-binding-demo.css',
})
export class TwoWayDataBindingDemo {
  title:string = "Two way data binding demo 1.";
  name:string = "";

  clearName(){
    this.name = "";
  }
}
