import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NameGmail } from './name-gmail';

describe('NameGmail', () => {
  let component: NameGmail;
  let fixture: ComponentFixture<NameGmail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NameGmail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NameGmail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
