import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonLoginComponent } from './person-login.component';

describe('UserLoginComponent', () => {
  let component: PersonLoginComponent;
  let fixture: ComponentFixture<PersonLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
