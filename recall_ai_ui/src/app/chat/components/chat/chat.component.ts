import { AfterViewChecked, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AccountService } from '@app/_services';

type Message = {
  text?: string;
  type: MessageType;
}

enum MessageType {
  Bot = 'bot',
  User = 'user',
  Loading = 'loading'
}

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, AfterViewChecked {
  @ViewChild('messageContainer') private messageContainer: ElementRef | undefined;
  @Input() public display: string | undefined;
  query: string = '';
  originalNotes: string[] = [];
  rephrasedNotes: string = '';
  errorMessage: string = '';
  public form = this.formBuilder.group({
    message: ['']
  });

  public messages: Array<Message> = [];
  private canSendMessage = true;

  constructor(private formBuilder: FormBuilder,  private accountService: AccountService,){}

  ngOnInit(): void {
    this.getBotMessage();
  }

  ngAfterViewChecked(): void {        
    this.scrollToBottom();        
  } 

  public onClickSendMessage(): void {
    const message = this.form.get('message')?.value;

    if (message && this.canSendMessage) {
      const userMessage: Message = {text: message, type: MessageType.User};
      this.messages.push(userMessage);

      this.form.get('message')?.setValue('');
      this.form.updateValueAndValidity();
      this.searchNotes(message);
    }
  }

  private getBotMessage(): void {
    this.canSendMessage = false;
    const waitMessage: Message = {type: MessageType.Loading};
    this.messages.push(waitMessage);

    setTimeout(() => {
      this.messages.pop();
      const botMessage: Message = {text: 'Hello! How can I help you?', type: MessageType.Bot};
      this.messages.push(botMessage);
      this.canSendMessage = true;
   }, 2000);
  }

  searchNotes(message: string) {
    if (!message.trim()) {
      this.errorMessage = 'Please enter a query';
      return;
    }
    this.canSendMessage = false;
    const waitMessage: Message = {type: MessageType.Loading};
    this.messages.push(waitMessage);
    var userid = this.accountService.accountValue?.userId;
    
    console.log(userid);
    this.accountService.searchNotes(message, userid ?? 0).subscribe(
      response => {
        this.originalNotes = response.originalNotes;
      
        // Parse the rephrasedNotes JSON
        if (response.rephrasedNotes) {
          const parsedRephrased = JSON.parse(response.rephrasedNotes);
          this.rephrasedNotes =  parsedRephrased.result;
        }
        this.errorMessage = ''; // Clear any previous error message
        this.messages.pop();
        const botMessage: Message = {text: this.rephrasedNotes, type: MessageType.Bot};
        this.messages.push(botMessage);
        this.canSendMessage = true;
      },
      error => {
        this.errorMessage = 'No notes found matching your query or an error occurred.';
      }
    );
  }

  public onClickEnter(event: Event): void {
    event.preventDefault();
    this.onClickSendMessage();
  }

  private scrollToBottom(): void {
    if (this.messageContainer) {
      this.messageContainer.nativeElement.scrollTop = this.messageContainer.nativeElement.scrollHeight;         
    }
  }
}
