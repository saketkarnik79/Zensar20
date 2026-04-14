import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoWayDataBindingDemo3 } from './two-way-data-binding-demo3';

describe('TwoWayDataBindingDemo3', () => {
  let component: TwoWayDataBindingDemo3;
  let fixture: ComponentFixture<TwoWayDataBindingDemo3>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TwoWayDataBindingDemo3],
    }).compileComponents();

    fixture = TestBed.createComponent(TwoWayDataBindingDemo3);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
