import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgClassDemo } from './ng-class-demo';

describe('NgClassDemo', () => {
  let component: NgClassDemo;
  let fixture: ComponentFixture<NgClassDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NgClassDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(NgClassDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
