import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RespondToQuestionService {

  public url: string = 'http://localhost:5000/api/RespondToQuestions/MonitoringProductHomePage/';
  constructor( private https: HttpClient ) { }

  GetProductByProductNumber(prodNumber : string){

    return this.https.get(this.url + 'Description/{productNumber}');
  }

  GetSpecificProduct(body: any){

    return this.https.post('http://localhost:5000/api/RespondToQuestions/MonitoringProduct', body);
  }

  SendEmailToPersonal(body: any){
    
    return this.https.post('http://localhost:5000/api/Alert/email', body);
  }
}
