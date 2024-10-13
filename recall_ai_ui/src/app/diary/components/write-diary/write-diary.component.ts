import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService, AlertService } from '@app/_services';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/diary/diary.service';

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
    private diaryService: DiaryService,
    private alertService: AlertService,
    private accountService: AccountService,
    private datePipe: DatePipe
  ){}

  onClickSendMessage(){
    if (this.form.valid) {
      const formData = this.form.value;
      const payload = {
        userId: this.accountService.accountValue?.id ? +this.accountService.accountValue.id : 1,
        note: formData.note || '',
        noteDate: formData.date ? new Date(formData.date) : new Date(),
        mood: formData.mood ?? undefined,
      };
      this.diaryService.add(payload).subscribe({
        next: () => {
          this.form.reset();
          this.alertService.success('Successfully Added!');
        }
      })
    }
  }

}
