import { TestBed } from '@angular/core/testing';

import { TransfersServices } from './transfers-services';

describe('TransfersServices', () => {
  let service: TransfersServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransfersServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
