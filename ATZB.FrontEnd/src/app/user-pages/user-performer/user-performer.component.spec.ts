import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPerformerComponent } from './user-performer.component';

describe('UserPerformerComponent', () => {
  let component: UserPerformerComponent;
  let fixture: ComponentFixture<UserPerformerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserPerformerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPerformerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
