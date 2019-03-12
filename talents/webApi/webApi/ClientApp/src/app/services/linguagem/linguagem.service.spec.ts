import { TestBed, inject } from '@angular/core/testing';

import { LinguagemService } from './linguagem.service';

describe('LinguagemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LinguagemService]
    });
  });

  it('should be created', inject([LinguagemService], (service: LinguagemService) => {
    expect(service).toBeTruthy();
  }));
});
