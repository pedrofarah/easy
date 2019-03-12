import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinguagemComponent } from './linguagem.component';

describe('LinguagemComponent', () => {
  let component: LinguagemComponent;
  let fixture: ComponentFixture<LinguagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinguagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinguagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
