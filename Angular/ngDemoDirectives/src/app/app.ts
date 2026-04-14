import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgIfDemo } from './ng-if-demo/ng-if-demo';
import { NgSwitchDemo } from "./ng-switch-demo/ng-switch-demo";
import { NgClassDemo } from './ng-class-demo/ng-class-demo';
import { TtClass } from "./tt-class";
import { TtToggleDirective } from './tt-toggle-directive';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgIfDemo, NgSwitchDemo, NgClassDemo, TtClass, TtToggleDirective, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ngDemoDirectives');
}
