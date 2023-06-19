import { TestBed } from '@angular/core/testing';

import { CalculocdbService } from './calculocdb.service';
import { HttpClientTestingModule  } from '@angular/common/http/testing';

describe('CalculocdbService', () => {
  let service: CalculocdbService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule ]
    });
    service = TestBed.inject(CalculocdbService);
  });

  it('should service be created', () => {
    expect(service).toBeTruthy();
  });
});
