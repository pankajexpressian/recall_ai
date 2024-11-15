import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { DiaryRoutingModule } from './diary-routing.module';
import { WriteDiaryComponent } from './components/write-diary/write-diary.component';
import { ViewDiaryComponent } from './components/view-diary/view-diary.component';
import { MaterialModule } from '@app/material.module';
import { TruncatePipe } from '@app/_pipes/truncate-text.pipe';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        DiaryRoutingModule,
        MaterialModule
    ],
    declarations: [
        WriteDiaryComponent,
        ViewDiaryComponent,
        TruncatePipe
    ]
})
export class DiaryModule { }