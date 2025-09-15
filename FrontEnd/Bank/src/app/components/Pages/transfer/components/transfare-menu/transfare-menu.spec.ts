import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransfareMenu } from './transfare-menu';

describe('TransfareMenu', () => {
  let component: TransfareMenu;
  let fixture: ComponentFixture<TransfareMenu>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransfareMenu]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransfareMenu);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
