import { TestBed } from '@angular/core/testing';

import { RespondToQuestionService } from './respond-to-question.service';

describe('RespondToQuestionService', () => {
  let service: RespondToQuestionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RespondToQuestionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
