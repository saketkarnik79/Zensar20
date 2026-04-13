import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateExpressionDemo } from './template-expression-demo';

describe('TemplateExpressionDemo', () => {
  let component: TemplateExpressionDemo;
  let fixture: ComponentFixture<TemplateExpressionDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateExpressionDemo],
    }).compileComponents();

    fixture = TestBed.createComponent(TemplateExpressionDemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
