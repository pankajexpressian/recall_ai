import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '@app/_services';

@Component({
    templateUrl: 'home.component.html',
    styleUrls: ['./home.component.less']
})

export class HomeComponent {
    account = this.accountService.accountValue;
    moods = [{
        name: 'ANGER',
        value: 0
    }, {
        name: 'DISGUST',
        value: 1
    }, {
        name: 'FEAR',
        value: 2
    }, {
        name: 'JOY',
        value: 3
    }, {
        name: 'NEUTRAL',
        value: 4
    }, {
        name: 'SADNESS',
        value: 5
    }, {
        name: 'SURPRISE',
        value: 6
    }];

    constructor(
        private accountService: AccountService,
        private router: Router
    ) { }

    onClick(route: string) {
        this.router.navigateByUrl(route);
    }
}