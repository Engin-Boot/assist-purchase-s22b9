import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductManagementService {

  public url: string = 'https://localhost:5001/api/ProductConfigure/getAllProducts';
  constructor( private http: HttpClient ) { }

  GetProductInfo(): Observable<GetAllProduct[]> {
    
    return this.http.get<GetAllProduct[]>(this.url);
  }
}
