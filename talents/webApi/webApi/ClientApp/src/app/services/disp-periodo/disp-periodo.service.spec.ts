import { TestBed } from '@angular/core/testing';

import { DispPeriodoService } from './disp-periodo.service';

describe('DispPeriodoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DispPeriodoService = TestBed.get(DispPeriodoService);
    expect(service).toBeTruthy();
  });
});
