import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ng-if-demo',
  imports: [CommonModule],
  templateUrl: './ng-if-demo.html',
  styleUrl: './ng-if-demo.css',
})
export class NgIfDemo {
  visible:boolean=true;
}
