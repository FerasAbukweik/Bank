import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAccountContainer } from './add-account-container';

describe('AddAccountContainer', () => {
  let component: AddAccountContainer;
  let fixture: ComponentFixture<AddAccountContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddAccountContainer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddAccountContainer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
