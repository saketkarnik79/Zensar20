import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
//   template: `<div class="app">
//   <h1>{{ title() }}</h1>
//   <h2>Welcome to Angular 21!</h2>
//   <router-outlet></router-outlet>
// </div>
// `,
styleUrl: './app.css',
//   styles: `.app {
//   text-align: center;
//   margin-top: 50px;
// }
// `,
})
export class App {
  protected readonly title = signal('ngDemoHelloWorld');
}
