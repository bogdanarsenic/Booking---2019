import { TestBed } from '@angular/core/testing';

import { CheckavailService } from './checkavail.service';

describe('CheckavailService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CheckavailService = TestBed.get(CheckavailService);
    expect(service).toBeTruthy();
  });
});
