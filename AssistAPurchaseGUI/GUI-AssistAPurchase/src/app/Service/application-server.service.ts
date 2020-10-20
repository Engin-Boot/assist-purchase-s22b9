import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetAllProductInfo } from 'src/app/DataCollector/GetAllProduct';

@Injectable({
  providedIn: 'root'
})
export class ApplicationServerService {

  public url: string = 'https://localhost:5001/api/ProductConfigure/getAllProducts';
  constructor(private http: HttpClient) { }
  getProductInfo(): Observable<GetAllProductInfo[]>{
    console.log(this.http.get<GetAllProductInfo[]>(this.url))
    //return this.http.get<Detail[]>(this.url);
    return this.http.get<GetAllProductInfo[]>(this.url);
  }
}
