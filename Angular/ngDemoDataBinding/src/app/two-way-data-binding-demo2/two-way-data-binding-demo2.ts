import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-two-way-data-binding-demo2',
  imports: [FormsModule],
  templateUrl: './two-way-data-binding-demo2.html',
  styleUrl: './two-way-data-binding-demo2.css',
})
export class TwoWayDataBindingDemo2 {
  title:string = "Two way data binding demo 2!"
  name:string="";
  clearName(){
    this.name="";
  }
}
