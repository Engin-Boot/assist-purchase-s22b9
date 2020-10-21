import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductManagementService {

  public url: string = 'http://localhost:5000/api/ProductConfigure/getAllProducts';
  constructor( private https: HttpClient ) { }

  public GetProductInfo() {
    
    return this.https.get(this.url);
  }
}
