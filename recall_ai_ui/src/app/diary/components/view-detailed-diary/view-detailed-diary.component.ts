import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Diary } from '@app/_models';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/diary/diary.service';

@Component({
  selector: 'app-view-detailed-diary',
  templateUrl: './view-detailed-diary.component.html',
  styleUrls: ['./view-detailed-diary.component.less']
})
export class ViewDetailedDiaryComponent {

  moods = MOODS;
  diary: Diary = {    "diaryId": 43,    "userId": 1,    "note": "We are done with our hacktelligene. and it'sa cheerable moments for all of us.",    "noteDate": "2024-10-13T00:00:00",    "mood": 4,    "insertedOn": "2024-10-13T20:39:51.070007"  } ;
  constructor(private route: ActivatedRoute, private diaryService: DiaryService) {
    const userId = this.route.snapshot.paramMap.get('userId');
    const diaryId = this.route.snapshot.paramMap.get('diaryId');
    console.log(userId, diaryId);
}

}
