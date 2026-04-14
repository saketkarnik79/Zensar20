import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyBindingDemo } from './property-binding-demo';

describe('PropertyBindingDemo', () => {
  let component: PropertyBindingDemo;
  let fixture: ComponentFixture<PropertyBindingDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PropertyBindingDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(PropertyBindingDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
