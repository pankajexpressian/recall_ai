import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '@app/_services';
import { MOODS } from '@app/app.constants';

@Component({
    templateUrl: 'home.component.html',
    styleUrls: ['./home.component.less']
})

export class HomeComponent {
    account = this.accountService.accountValue;
    moods = MOODS;

    constructor(
        private accountService: AccountService,
        private router: Router
    ) { }

    onClick(route: string) {
        this.router.navigateByUrl(route);
    }
}