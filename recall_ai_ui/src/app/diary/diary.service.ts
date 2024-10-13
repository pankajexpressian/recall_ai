import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';

const baseUrl = `${environment.apiUrl}/users`;

type User = {
    email: string;
    firstName: string;
    lastName: string;
    userId: number;
};

@Injectable({ providedIn: 'root' })
export class DiaryService {

    constructor(
        private http: HttpClient
    ) {
    }

    add(data: {
        userId: number;
        note: string;
        noteDate: Date | string;
        mood?: number;
    }) {
        return this.http.post<User[]>(`${baseUrl}/${data.userId}/diaries`, data);
    }
}