import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoWayDataBindingDemo } from './two-way-data-binding-demo';

describe('TwoWayDataBindingDemo', () => {
  let component: TwoWayDataBindingDemo;
  let fixture: ComponentFixture<TwoWayDataBindingDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TwoWayDataBindingDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(TwoWayDataBindingDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
