import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinguagemCadastroComponent } from './linguagem-cadastro.component';

describe('LinguagemCadastroComponent', () => {
  let component: LinguagemCadastroComponent;
  let fixture: ComponentFixture<LinguagemCadastroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinguagemCadastroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinguagemCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
