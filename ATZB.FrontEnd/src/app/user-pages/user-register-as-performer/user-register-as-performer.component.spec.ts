import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserRegisterAsPerformerComponent } from './user-register-as-performer.component';

describe('UserRegisterAsPerformerComponent', () => {
  let component: UserRegisterAsPerformerComponent;
  let fixture: ComponentFixture<UserRegisterAsPerformerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserRegisterAsPerformerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserRegisterAsPerformerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
