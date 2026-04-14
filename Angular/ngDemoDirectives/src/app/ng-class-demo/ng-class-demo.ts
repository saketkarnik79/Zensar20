import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ng-class-demo',
  imports: [CommonModule],
  templateUrl: './ng-class-demo.html',
  styleUrl: './ng-class-demo.css',
})
export class NgClassDemo {
  css:string='primary big';
}
