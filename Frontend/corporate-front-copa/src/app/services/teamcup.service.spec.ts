import { TestBed } from '@angular/core/testing';

import { TeamcupService } from './teamcup.service';

describe('TeamcupService', () => {
  let service: TeamcupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeamcupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
