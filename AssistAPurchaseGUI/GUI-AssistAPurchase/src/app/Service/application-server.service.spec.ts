import { TestBed } from '@angular/core/testing';

import { ApplicationServerService } from './application-server.service';

describe('ApplicationServerService', () => {
  let service: ApplicationServerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicationServerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
