import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AccountService, AlertService, DiaryService } from '@app/_services';
import { SpotifyService, TrackInfo } from '@app/_services/spotify.service';
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
  token: string | null | undefined;
  isTokenAvailable = false;
  recommendations: TrackInfo[] = [];
  constructor(
    private accountService: AccountService,
    private diaryService: DiaryService,
    private alertService: AlertService,
    private router: Router,
    private datePipe: DatePipe,
    private route: ActivatedRoute,
    private spotifyService: SpotifyService
  ) {
    this.todaysMood = this.diaryService.todaysMood;
  }
  ngOnInit(): void {
    const token = localStorage.getItem('spotifyToken');
    if (token && token != '') {
      this.isTokenAvailable = true;
    // Token exists, proceed to use it for recommendations or other Spotify API calls
    } else {
      this.isTokenAvailable = false;
    }
      // Get the token from the URL query parameters
      this.route.queryParamMap.subscribe(params => {
          this.token = params.get('token');

        if (this.token) {
          this.isTokenAvailable = true;
              // Store the token, or use it to make API calls as needed
              localStorage.setItem('spotifyToken', this.token);
          }
      });
  }
  onClick(route: string) {
    this.router.navigateByUrl(route);
  }
  loginWithSpotify() {
    window.location.href = 'http://localhost:5076/api/spotify/login';
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
        this.getRecommendations(mood.name);
      },
    });
  }

  getRecommendations(mood: string) {
    const token = localStorage.getItem('spotifyToken') ?? null;
    if (token) {
    this.spotifyService.getRecommendations(mood, token).subscribe((data) => {
      this.recommendations = data;
    });
    } else {
      alert('please login to spotify to get music recommendation');
    }
  }
}
