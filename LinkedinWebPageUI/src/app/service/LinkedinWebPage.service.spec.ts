/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LinkedinWebPageService } from './LinkedinWebPage.service';

describe('Service: LinkedinWebPage', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LinkedinWebPageService]
    });
  });

  it('should ...', inject([LinkedinWebPageService], (service: LinkedinWebPageService) => {
    expect(service).toBeTruthy();
  }));
});
