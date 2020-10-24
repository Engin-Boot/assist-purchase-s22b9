import { Component, OnInit } from '@angular/core';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { HomeComponent } from 'src/app/Component/home/home.component';
import { ProductManagementService } from 'src/app/Controller/product-management.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  public product : GetAllProduct[] = [];
  productNumber : string;
  constructor(private productDetail: ProductManagementService) {  }

  ngOnInit(): void {
    this.GetProoductFromProductNumber();
  }


  GetProoductFromProductNumber(){
    this.productNumber = HomeComponent.prodNumber;
    let observable=this.productDetail.ReturnProductSearchByProductNumber(this.productNumber);
    
    observable.subscribe((data:GetAllProduct)=>{
      this.product[0] = data;
    });
    
  }

  SetProductNumberToNull(){
    HomeComponent.prodNumber = '';
  }
}
