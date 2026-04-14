import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-ng-switch-demo',
  imports: [CommonModule, FormsModule],
  templateUrl: './ng-switch-demo.html',
  styleUrl: './ng-switch-demo.css',
})
export class NgSwitchDemo {
  num: number=0;
}
