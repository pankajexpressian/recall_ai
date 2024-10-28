import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService, AlertService, DiaryService } from '@app/_services';
import { MOOD, MOODS } from '@app/app.constants';

@Component({
  templateUrl: 'home.component.html',
  styleUrls: ['./home.component.less'],
  providers: [DatePipe]
})
export class HomeComponent {
  account = this.accountService.accountValue;
  moods = MOODS;
  todaysMood?: number;

  constructor(
    private accountService: AccountService,
    private diaryService: DiaryService,
    private alertService: AlertService,
    private router: Router,
    private datePipe: DatePipe
  ) {
    this.todaysMood = this.diaryService.todaysMood;
  }

  onClick(route: string) {
    this.router.navigateByUrl(route);
  }

  submitTodayMood(mood: MOOD) {
    const currentDate = new Date();
    const time = this.datePipe.transform(currentDate, 'shortTime');
    const payload = {
      userId: this.accountService.accountValue?.userId ?? 0,
      note: `Today I was feeling ${mood.name} at ${time}.`,
      noteDate: currentDate,
      mood: mood.value,
    };
    this.diaryService.add(payload).subscribe({
      next: () => {
        this.todaysMood = mood.value;
        this.diaryService.todaysMood = mood.value;
        this.alertService.success('Mood successfully captured!');
      },
    });
  }
}
