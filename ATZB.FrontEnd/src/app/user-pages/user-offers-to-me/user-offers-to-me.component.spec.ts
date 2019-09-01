import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOffersToMeComponent } from './user-offers-to-me.component';

describe('UserOffersToMeComponent', () => {
  let component: UserOffersToMeComponent;
  let fixture: ComponentFixture<UserOffersToMeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserOffersToMeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOffersToMeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
