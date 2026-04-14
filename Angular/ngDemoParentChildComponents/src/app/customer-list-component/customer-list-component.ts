import { Component } from '@angular/core';
import { Customer } from '../../models/customer';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'customer-list',
  imports: [CommonModule],
  templateUrl: './customer-list-component.html',
  styleUrl: './customer-list-component.css',
})
export class CustomerListComponent {
  customers: Customer[] = [
    {customerID: 1, name: 'Rahuld Dravid', address: '', city: 'Banglaore', state: 'Karnataka', country: 'India'},
    {customerID: 2, name: 'Sachin Tendulkar', address: '', city: 'Mumbai', state: 'Maharastra', country: 'India'},
    {customerID: 3, name: 'Saurrav Ganguly', address: '', city: 'Kolkata', state: 'West Bengal', country: 'India'},
    {customerID: 4, name: 'Mahendra Singh Dhoni', address: '', city: 'Ranchi', state: 'Bihar', country: 'India'},
    {customerID: 5, name: 'Virat Kohli', address: '', city: 'Delhi', state: 'Delhi', country: 'India'}
  ];
}
