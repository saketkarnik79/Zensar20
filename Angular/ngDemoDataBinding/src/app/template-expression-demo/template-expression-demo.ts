import { Component } from '@angular/core';

@Component({
  selector: 'app-template-expression-demo',
  imports: [],
  templateUrl: './template-expression-demo.html',
  styleUrl: './template-expression-demo.css',
})
export class TemplateExpressionDemo {
   firstName: string = 'John' ;
   lastName: string = 'Doe';
   age: number = 35;
   isLoggedIn: boolean = true;
}
