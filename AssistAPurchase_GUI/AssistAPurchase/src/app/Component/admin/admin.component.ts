import { Component, OnInit } from '@angular/core';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { Product } from 'src/app/Component/admin/product'
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  public prodDetail: GetAllProduct[] = [];
  // public productModel: GetAllProduct[]=[];
  
  public index : number;
  addProductdisplay='none';
  updateProductDisplay='none';
  deleteProductDisplay='none';
  getProductDispay='block'
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
    this.OnInsertProduct();
  }
  
  DeleteProductByProductId(productId: string): void{
    this.productDetail.DeleteProduct(productId);
  }
  OnInsertProduct(){
    console.log("product:" + this.productModel.productNumber);
  }
   productModel = new Product("","","","","","","","","","","", "","","","","","");



  showGetProductForm(){
    this.getProductDispay='block';
    this.addProductdisplay='none';
  this.deleteProductDisplay='none';
  this.updateProductDisplay='none';
 }

  showAddProductForm(){
    this.getProductDispay='none';
    this.addProductdisplay='block';
  this.deleteProductDisplay='none';
  this.updateProductDisplay='none';
 }

 
 showUpdateProductForm(){
  this.getProductDispay='none';
  this.addProductdisplay='none';
  this.deleteProductDisplay='none';
  this.updateProductDisplay='block';
}
showDeleteProductForm(){
  this.getProductDispay='none';
  this.addProductdisplay='none';
  this.deleteProductDisplay='block';
  this.updateProductDisplay='none';
}


}
