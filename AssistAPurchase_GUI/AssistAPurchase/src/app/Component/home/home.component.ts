import { Component, OnInit } from '@angular/core';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { RespondToQuestionService } from 'src/app/Controller/respond-to-question.service';
import { AdminLoginService } from 'src/app/Controller/admin-login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  title = 'AssistAPurchase';
  closeResult = ''; 
  public prodDetail: GetAllProduct[] = [];
  isFilterApplied = false;
  isNameSelected = false;
  constructor(private productDetail: ProductManagementService, private adminLogin : AdminLoginService) { }
  
  ngOnInit(): void {
    this.GetAllProduct();
  }
  GetAllProduct(){
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

  ShowSearchedProduct(serachProduct : string){

    this.prodDetail = [];
    this.isFilterApplied = true;
    let observable=this.productDetail.ReturnProductSearchByProductNumber(serachProduct);
    
    observable.subscribe((data:GetAllProduct)=>{
      this.prodDetail[0] = data;
    },
    (error:any)=>{
     this.GetAllProduct();
     this.isFilterApplied = false;
    },
    ()=>{
      console.log("Completed");
    });
  }

  RemoveFilter(){
    this.GetAllProduct();
    this.isFilterApplied = false;
  }
  selectInput() {
    if (this.isNameSelected == true) {
      this.isNameSelected = false;
    } else {
      this.isNameSelected = true;
    }
  }

  CancelLogin(){
    this.isNameSelected = false;
  }
  
  ValidateCredentials(email: string , password: string){
    console.log(email + password);
    let data = {email: email, password: password};
    let observable=this.adminLogin.ValidateAdmin(data);
    observable.subscribe((data:Response)=>{
      console.log(data);
    },
    (error:any)=>{
     //alert(error);
     console.log(error)
    },
    ()=>{
      console.log("Completed");
    });
  }

}
