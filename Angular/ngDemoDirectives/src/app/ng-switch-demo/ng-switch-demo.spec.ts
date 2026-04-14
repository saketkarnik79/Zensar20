import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgSwitchDemo } from './ng-switch-demo';

describe('NgSwitchDemo', () => {
  let component: NgSwitchDemo;
  let fixture: ComponentFixture<NgSwitchDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NgSwitchDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(NgSwitchDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
