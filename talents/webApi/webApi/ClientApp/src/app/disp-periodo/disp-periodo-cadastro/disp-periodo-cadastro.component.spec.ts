import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DispPeriodoCadastroComponent } from './disp-periodo-cadastro.component';

describe('DispPeriodoCadastroComponent', () => {
  let component: DispPeriodoCadastroComponent;
  let fixture: ComponentFixture<DispPeriodoCadastroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DispPeriodoCadastroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DispPeriodoCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
