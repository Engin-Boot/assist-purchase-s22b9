import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonnalSupportComponent } from './personnal-support.component';

describe('PersonnalSupportComponent', () => {
  let component: PersonnalSupportComponent;
  let fixture: ComponentFixture<PersonnalSupportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonnalSupportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonnalSupportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
