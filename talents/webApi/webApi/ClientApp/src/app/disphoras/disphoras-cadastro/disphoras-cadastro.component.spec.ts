import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DispHorasCadastroComponent } from './disphoras-cadastro.component';

describe('DisphorasCadastroComponent', () => {
  let component: DispHorasCadastroComponent;
  let fixture: ComponentFixture<DispHorasCadastroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DispHorasCadastroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DispHorasCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
