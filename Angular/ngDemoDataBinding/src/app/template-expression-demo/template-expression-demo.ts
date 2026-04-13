import { Component } from '@angular/core';

@Component({
  selector: 'app-template-expression-demo',
  imports: [],
  templateUrl: './template-expression-demo.html',
  styleUrl: './template-expression-demo.css',
})
export class TemplateExpressionDemo {
  firstName = 'John';
  lastName = 'Doe';
  age = 30;
  isLoggedIn = true;
}
