import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoWayDataBindingDemo2 } from './two-way-data-binding-demo2';

describe('TwoWayDataBindingDemo2', () => {
  let component: TwoWayDataBindingDemo2;
  let fixture: ComponentFixture<TwoWayDataBindingDemo2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TwoWayDataBindingDemo2],
    }).compileComponents();

    fixture = TestBed.createComponent(TwoWayDataBindingDemo2);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
