import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomerListComponent } from './customer-list-component/customer-list-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CustomerListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ngDemoParentChildComponents');
}
