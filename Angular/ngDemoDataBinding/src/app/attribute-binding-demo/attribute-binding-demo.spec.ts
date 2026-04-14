import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttributeBindingDemo } from './attribute-binding-demo';

describe('AttributeBindingDemo', () => {
  let component: AttributeBindingDemo;
  let fixture: ComponentFixture<AttributeBindingDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttributeBindingDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(AttributeBindingDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
