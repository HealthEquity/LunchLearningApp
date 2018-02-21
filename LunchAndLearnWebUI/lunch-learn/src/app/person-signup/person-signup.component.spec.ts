import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonSignupComponent } from './person-signup.component';

describe('UserSignupComponent', () => {
  let component: PersonSignupComponent;
  let fixture: ComponentFixture<PersonSignupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonSignupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonSignupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
