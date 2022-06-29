import { TestBed } from '@angular/core/testing';

import { ApishippersService } from './apishippers.service';

describe('ApishippersService', () => {
  let service: ApishippersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApishippersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
