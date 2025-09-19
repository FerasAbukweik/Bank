import { TestBed } from '@angular/core/testing';

import { AccountTypesServices } from './account-types-services';

describe('AccountTypeServices', () => {
  let service: AccountTypesServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountTypesServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
