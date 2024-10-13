import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WriteDiaryComponent } from './components/write-diary/write-diary.component';
import { ViewDiaryComponent } from './components/view-diary/view-diary.component';


const routes: Routes = [
    { path: '', component: WriteDiaryComponent },
    { path: 'view-diary', component: ViewDiaryComponent },
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DiaryRoutingModule { }