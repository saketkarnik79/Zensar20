import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TemplateExpressionDemo } from './template-expression-demo/template-expression-demo';
import { PropertyBindingDemo } from './property-binding-demo/property-binding-demo';
import { AttributeBindingDemo } from './attribute-binding-demo/attribute-binding-demo';
import { TwoWayDataBindingDemo } from './two-way-data-binding-demo/two-way-data-binding-demo';
import { TwoWayDataBindingDemo2 } from './two-way-data-binding-demo2/two-way-data-binding-demo2';
import { TwoWayDataBindingDemo3 } from './two-way-data-binding-demo3/two-way-data-binding-demo3';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TemplateExpressionDemo, PropertyBindingDemo, AttributeBindingDemo, 
    TwoWayDataBindingDemo, TwoWayDataBindingDemo2, TwoWayDataBindingDemo3],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ngDemoDataBinding');
  counter:number=0;

  clearCount(){
    this.counter=0;
  }
}
