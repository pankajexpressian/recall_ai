import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Diary } from '@app/_models/diary';
import { AccountService } from '@app/_services';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/diary/diary.service';

@Component({
  selector: 'app-view-diary',
  templateUrl: './view-diary.component.html',
  styleUrls: ['./view-diary.component.less']
})
export class ViewDiaryComponent {

  moods = MOODS

  diaries: Diary[] = [];
  
  constructor(
    private diaryService: DiaryService,
    private accountService: AccountService,
    private router: Router
  ) {
    const userId = this.accountService.accountValue?.userId ?? 0;
    this.diaryService.getDiaries(userId).subscribe({
      next: (data: Diary[]) => this.diaries = data
    })
  }

  openDiaryDetails(diary: Diary) {
    this.router.navigate(['/diary/view-diary',diary.userId, diary.diaryId]);
  }

}
