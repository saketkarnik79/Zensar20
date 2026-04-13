import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TemplateExpressionDemo } from './template-expression-demo/template-expression-demo';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TemplateExpressionDemo],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ngDemoDataBinding');
}
