import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ChatRoutingModule } from './chat-routing.module';
import { ChatComponent } from './components/chat/chat.component';
import { MaterialModule } from '@app/material.module';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ChatRoutingModule,
        MaterialModule
    ],
    declarations: [
        ChatComponent
    ]
})
export class ChatModule { }