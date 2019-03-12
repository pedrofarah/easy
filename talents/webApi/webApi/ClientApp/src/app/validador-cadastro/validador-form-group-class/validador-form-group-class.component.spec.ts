import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidadorFormGroupClassComponent } from './validador-form-group-class.component';

describe('ValidadorFormGroupClassComponent', () => {
  let component: ValidadorFormGroupClassComponent;
  let fixture: ComponentFixture<ValidadorFormGroupClassComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ValidadorFormGroupClassComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidadorFormGroupClassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
