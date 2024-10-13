import { Component } from '@angular/core';
import { MOODS } from '@app/app.constants';

@Component({
  selector: 'app-view-diary',
  templateUrl: './view-diary.component.html',
  styleUrls: ['./view-diary.component.less']
})
export class ViewDiaryComponent {

  moods = MOODS

  diaries = [
    {
      "diaryId": 1,
      "userId": 1,
      "note": "Feeling great today! I had a call with Lovelesh, Arun and Pankaj regarding hackathon today. It is going great so far. we were able to complete an MVP. Hoping for best.",
      "noteDate": "2024-10-10T11:23:49.1695465",
      "mood": 0,
      "insertedOn": "2024-10-10T11:23:49.1695465"
    },
    {
      "diaryId": 11,
      "userId": 1,
      "note": "Feeling great today!",
      "noteDate": "2024-10-10T11:23:49.1695469",
      "mood": 1,
      "insertedOn": "2024-10-10T11:23:49.1695468"
    },
    {
      "diaryId": 12,
      "userId": 1,
      "note": "Feeling great today!",
      "noteDate": "2024-10-10T11:23:49.1695471",
      "mood": 2,
      "insertedOn": "2024-10-10T11:23:49.169547"
    }
  ];

}
