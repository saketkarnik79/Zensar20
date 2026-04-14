import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgIfDemo } from './ng-if-demo';

describe('NgIfDemo', () => {
  let component: NgIfDemo;
  let fixture: ComponentFixture<NgIfDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NgIfDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(NgIfDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
