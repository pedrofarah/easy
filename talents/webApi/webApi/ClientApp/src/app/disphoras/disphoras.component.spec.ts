import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DispHorasComponent } from './disphoras.component';

describe('DisphorasComponent', () => {
  let component: DispHorasComponent;
  let fixture: ComponentFixture<DispHorasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DispHorasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DispHorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
