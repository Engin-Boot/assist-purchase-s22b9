import { Component, OnInit } from '@angular/core';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  public prodDetail: GetAllProduct[] = [];
  public index : number;
  constructor(private productDetail: ProductManagementService) { }

  ngOnInit(): void {
    let observable=this.productDetail.GetProductInfo();
    
    observable.subscribe((data:GetAllProduct[])=>{
      this.prodDetail = data;
    },
    (error:any)=>{
     console.log(error);
    },
    ()=>{
      console.log("Completed");
    }); 
  }
  
  DeleteProductByProductId(productId: string): void{
    this.productDetail.DeleteProduct(productId);
  }
}
