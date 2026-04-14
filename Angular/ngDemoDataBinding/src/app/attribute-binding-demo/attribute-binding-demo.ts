import { Component } from '@angular/core';

@Component({
  selector: 'app-attribute-binding-demo',
  imports: [],
  templateUrl: './attribute-binding-demo.html',
  styleUrl: './attribute-binding-demo.css',
})
export class AttributeBindingDemo {
  // Dynamic values
  colSpanValue: number = 2;
  imageUrl: string = "https://images.pexels.com/photos/14553713/pexels-photo-14553713.jpeg"
  tableBorder: number = 1;
  ariaLabelText:string = 'Profile picture';
}
