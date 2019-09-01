import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserRegisterAsClientComponent } from './user-register-as-client.component';

describe('UserRegisterAsClientComponent', () => {
  let component: UserRegisterAsClientComponent;
  let fixture: ComponentFixture<UserRegisterAsClientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserRegisterAsClientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserRegisterAsClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
