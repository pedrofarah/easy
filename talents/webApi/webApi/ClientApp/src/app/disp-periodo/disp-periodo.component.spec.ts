import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DispPeriodoComponent } from './disp-periodo.component';

describe('DispPeriodoComponent', () => {
  let component: DispPeriodoComponent;
  let fixture: ComponentFixture<DispPeriodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DispPeriodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DispPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
