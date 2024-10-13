import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { DiaryRoutingModule } from './diary-routing.module';
import { WriteDiaryComponent } from './components/write-diary/write-diary.component';
import { ViewDiaryComponent } from './components/view-diary/view-diary.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        DiaryRoutingModule
    ],
    declarations: [
        WriteDiaryComponent,
        ViewDiaryComponent
    ]
})
export class DiaryModule { }