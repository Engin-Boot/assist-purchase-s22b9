import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductManagementService {

  public url: string = 'http://localhost:5000/api/ProductConfigure/';
  constructor( private https: HttpClient ) { }

  public GetProductInfo() {
    
    return this.https.get(this.url + 'getAllProducts');
  }

  public DeleteProduct(productId: string){
    return this.https.delete(this.url + productId);
  }

  public ReturnProductSearchByProductNumber(productNumber : string){

    return this.https.get(this.url + productNumber);
  }
}
