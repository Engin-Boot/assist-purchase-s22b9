import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chat-bot',
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css']
})
export class ChatBotComponent implements OnInit {

  hello = '';
  name = '';
  email = '';
  isProductFilterd = false;
  isReplied = false;
  isEmailEntered = false;
  constructor() { }

  ngOnInit(): void {
  }

  HelloBot(){
    this.isReplied = true;
    this.hello = "Hello";
  }
  SetInput(input: string){
    if(this.isProductFilterd == true){
      this.name = input;
      this.isEmailEntered = true;
      this.isProductFilterd = false
    }
    else if(this.isEmailEntered == true){
      this.isProductFilterd = false;
      this.email = input;
    }
  }
  Filter(){
    this.isProductFilterd = true;
  }
}
