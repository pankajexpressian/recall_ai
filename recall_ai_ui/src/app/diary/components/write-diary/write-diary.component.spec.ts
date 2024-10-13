import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WriteDiaryComponent } from './write-diary.component';

describe('WriteDiaryComponent', () => {
  let component: WriteDiaryComponent;
  let fixture: ComponentFixture<WriteDiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WriteDiaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WriteDiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
