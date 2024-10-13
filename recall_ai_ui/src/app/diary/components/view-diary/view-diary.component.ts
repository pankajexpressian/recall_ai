import { Component } from '@angular/core';
import { AccountService } from '@app/_services';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/diary/diary.service';

type Diary = {
  noteDate: Date;
  mood: number;
  note: string;
};

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
  ) {
    const userId = this.accountService.accountValue?.userId ?? 0;
    this.diaryService.getDiaries(userId).subscribe({
      next: (data: Diary[]) => this.diaries = data
    })
  }

}
