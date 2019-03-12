import { TestBed } from '@angular/core/testing';

import { DisphorasService } from './disphoras.service';

describe('DisphorasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DisphorasService = TestBed.get(DisphorasService);
    expect(service).toBeTruthy();
  });
});
