import { Component } from '@angular/core';
import {Location} from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { Diary } from '@app/_models';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/_services';


@Component({
  selector: 'app-view-detailed-diary',
  templateUrl: './view-detailed-diary.component.html',
  styleUrls: ['./view-detailed-diary.component.less'],
})
export class ViewDetailedDiaryComponent {
  moods = MOODS;
  diary: Diary | undefined;

  constructor(
    private route: ActivatedRoute,
    private _location: Location,
    private diaryService: DiaryService
  ) {
    const userId = this.route.snapshot.paramMap.get('userId');
    const diaryId = this.route.snapshot.paramMap.get('diaryId');
    if (userId && diaryId) {
      this.getDiary(+userId, +diaryId);
    }
  }

  getDiary(userId: number, diaryId: number) {
    this.diaryService.getDiary(userId, diaryId).subscribe({
      next: data => this.diary = data
    })
  }

  backClicked() {
    this._location.back();
  }
}
