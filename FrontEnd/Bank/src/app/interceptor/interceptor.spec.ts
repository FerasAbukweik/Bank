import { TestBed } from '@angular/core/testing';
import { HttpInterceptorFn } from '@angular/common/http';

import { Interceptor } from './interceptor';

describe('interceptorInterceptor', () => {
  const Interceptor: HttpInterceptorFn = (req, next) => 
    TestBed.runInInjectionContext(() => Interceptor(req, next));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(Interceptor).toBeTruthy();
  });
});
