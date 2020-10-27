import { Component, OnInit } from '@angular/core';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { Product } from 'src/app/Component/admin/product'
import { Router } from '@angular/router';
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
  constructor(private productDetail: ProductManagementService, private router: Router) {
    
   }

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
  
  
  AddProduct(invalid: boolean):void{
    if(invalid)
    {
      alert("Please enter the required details")
      return;
    }
    let observable=this.productDetail.InsertProduct(this.productModel)
    observable.subscribe((data:Response)=>{
      console.log(data);
    },
    (error:any)=>{
     //alert(error);
     console.log(error)
     alert("Unable to insert the product")
    },
    ()=>{
      console.log("Completed");
      alert("Product added successfully")
    });
    window.location.reload();
  }
  UpdateProduct(invalid: boolean):void{
    if(invalid)
    {
      alert("Please enter the required details")
      return;
    }
    let observable=this.productDetail.UpdateProductController(this.productModel)
    observable.subscribe((data:Response)=>{
      console.log(data);
    },
    (error:any)=>{
     //alert(error);
     console.log(error)
     alert("Unable to update the product")
    },
    ()=>{
      console.log("Completed");
      alert("Product updated successfully")
    });
    window.location.reload();
  }
  DeleteProduct(pid: string, invalid:boolean):void{
    console.log("pid:" + pid);
    if(invalid)
    {
      alert("Please enter the required details")
      return;
    }
    let observable=this.productDetail.DeleteProductController(pid)
    observable.subscribe((data:Response)=>{
      console.log(data);
    },
    (error:any)=>{
     //alert(error);
     console.log(error)
     alert("Unable to delete the product")
    },
    ()=>{
      console.log("Completed");
      alert("Product deleted successfully")
    });
    window.location.reload();
  }
  RedirectHome()
  {
    this.router.navigate(['']);
  }

  productModel = new Product("","","","NO","","NO","NO","NO","NO","NO","NO","NO","NO","","NO","NO","");
   


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
