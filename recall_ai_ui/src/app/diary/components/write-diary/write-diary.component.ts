import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MOODS } from '@app/app.constants';

@Component({
  selector: 'app-write-diary',
  templateUrl: './write-diary.component.html',
  styleUrls: ['./write-diary.component.less'],
  providers: [DatePipe]
})
export class WriteDiaryComponent {
  moods = MOODS;

  public form = new FormGroup({
    note: new FormControl('', [Validators.required]),
    date: new FormControl(this.datePipe.transform(new Date(), 'yyyy-MM-dd')),
    mood: new FormControl(),
  });

  get selectedMood() {
    return this.form.get('mood')?.value ?? null;
  }

  set selectedMood(value: number) {
    this.form.get('mood')?.setValue(value);
  }

  constructor(
    private formBuilder: FormBuilder,
    private datePipe: DatePipe
  ){}

  onClickEnter(event: Event){}
  onClickSendMessage(){}

}
