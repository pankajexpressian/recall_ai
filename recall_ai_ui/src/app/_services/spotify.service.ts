// spotify.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

import { environment } from '@environments/environment';
const baseUrl = `${environment.apiUrl}/spotify`;

export interface TrackInfo {
   name: string;
   artist: string;
   previewUrl: string;
   albumArt: string;
 }
@Injectable({
  providedIn: 'root'
})
export class SpotifyService {
   constructor(private http: HttpClient) {}

   getRecommendations(noteText: string, token: string | null): Observable<TrackInfo[]> {
      return this.http.post<TrackInfo[]>(`${baseUrl}/recommendations`, { token, noteText }).pipe(
        catchError((error) => {
          localStorage.removeItem('spotifyToken');
          console.error('Error fetching recommendations', error);
          return throwError('Failed to load recommended tracks, please try again later.');
        })
      );
  }
}
