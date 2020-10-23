import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RespondToQuestionService {

  public url: string = 'https://localhost:5001/api/RespondToQuestions/MonitoringProductHomePage/';
  constructor( private https: HttpClient ) { }

  GetProductByProductNumber(prodNumber : string){

    return this.https.get(this.url + 'Description/{productNumber}');
  }
}
