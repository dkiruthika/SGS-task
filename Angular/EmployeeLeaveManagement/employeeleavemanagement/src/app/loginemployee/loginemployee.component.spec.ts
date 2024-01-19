import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginemployeeComponent } from './loginemployee.component';

describe('LoginemployeeComponent', () => {
  let component: LoginemployeeComponent;
  let fixture: ComponentFixture<LoginemployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginemployeeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoginemployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
