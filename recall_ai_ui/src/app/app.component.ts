import { Component } from '@angular/core';

import { AccountService } from './_services';
import { Account, Role } from './_models';

@Component({ selector: 'app-root', templateUrl: 'app.component.html', styleUrls: ['./app.component.less'] })
export class AppComponent {
    Role = Role;
    account?: Account | null;

    constructor(private accountService: AccountService) {
        const userData = localStorage.getItem('userData');
        try {
            const parsedJsonData = JSON.parse(userData || '') || {};
            if (parsedJsonData.userId) {
                this.accountService.accountValue = parsedJsonData;
            }
        } catch (e) {}
        this.accountService.account.subscribe(x => {
            this.account = x;
            if (x) {
                localStorage.setItem('userData', JSON.stringify(x));
            } else {
                localStorage.removeItem('userData');
            }
        });
    }

    logout() {
        this.accountService.logout();
    }
}