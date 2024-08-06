import { TestBed } from '@angular/core/testing';

import { CandleSticksService } from './candle-sticks.service';

describe('CandleSticksService', () => {
  let service: CandleSticksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CandleSticksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
