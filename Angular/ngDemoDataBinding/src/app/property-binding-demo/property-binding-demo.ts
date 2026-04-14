import { Component } from '@angular/core';

@Component({
  selector: 'app-property-binding-demo',
  imports: [],
  templateUrl: './property-binding-demo.html',
  styleUrl: './property-binding-demo.css',
})
export class PropertyBindingDemo {
  //Property Binding
  title: string = "Property Binding Demo";
  isDisabled: boolean = true;
  someHtml: string = "<em>Some Data</em>";

  //Class Property binding
  isActive: boolean = true;
  hasError: boolean = false;

  toggleIsActive(){
    this.isActive = !this.isActive;
  }

  toggleError(){
    this.hasError = !this.hasError;
  }

  // Dynamic style values
  textColor: string = 'blue';
  fontSize: number = 20;
  isHighlighted: boolean = true;

  toggleHighlight(){
    this.isHighlighted = ! this.isHighlighted;
    this.textColor = this.isHighlighted ? 'blue' : 'gray';
  }
}
