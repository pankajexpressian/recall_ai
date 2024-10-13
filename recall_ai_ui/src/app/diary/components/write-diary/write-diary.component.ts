import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService, AlertService } from '@app/_services';
import { MOODS } from '@app/app.constants';
import { DiaryService } from '@app/diary/diary.service';

@Component({
  selector: 'app-write-diary',
  templateUrl: './write-diary.component.html',
  styleUrls: ['./write-diary.component.less']
})
export class WriteDiaryComponent {
  moods = MOODS;
  today = new Date().toISOString().split('T')[0];

  public form = new FormGroup({
    note: new FormControl('', [Validators.required]),
    date: new FormControl(this.today),
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
    private accountService: AccountService
  ){}

  onClickSendMessage(){
    if (this.form.valid) {
      const formData = this.form.value;
      const payload = {
        userId: this.accountService.accountValue?.userId ?? 0,
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
