import { TestBed } from '@angular/core/testing';

import { CurrentClimateService } from './current-climate.service';

describe('CurrentClimateService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CurrentClimateService = TestBed.get(CurrentClimateService);
    expect(service).toBeTruthy();
  });
});
