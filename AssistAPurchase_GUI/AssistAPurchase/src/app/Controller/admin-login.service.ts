import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminLoginService {

  public url: string = 'http://localhost:5000/api/';
  constructor( private https: HttpClient ) { }

  public ValidateAdmin(body:any){
    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    //return this.https.post(this.url + 'User/Login', body, httpOptions);
    let observable=this.https.post(this.url+ 'User/Login', body);
    return observable;
  }
}
