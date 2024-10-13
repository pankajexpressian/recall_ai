import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDiaryComponent } from './view-diary.component';

describe('ViewDiaryComponent', () => {
  let component: ViewDiaryComponent;
  let fixture: ComponentFixture<ViewDiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewDiaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewDiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
