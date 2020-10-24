import { Component, OnInit, Injectable } from '@angular/core';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { RespondToQuestionService } from 'src/app/Controller/respond-to-question.service';
import { AdminLoginService } from 'src/app/Controller/admin-login.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  title = 'AssistAPurchase';
  closeResult = ''; 
  public prodDetail: GetAllProduct[] = [];
  public static prodNumber = '';
  isFilterApplied = false;
  isNameSelected = false;
  constructor(private productDetail: ProductManagementService, private adminLogin : AdminLoginService, 
     private router: Router) { }
  
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

    this.ViewProductSpecification(serachProduct);
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

  ViewProductSpecification(productNumber: string){
    HomeComponent.prodNumber = productNumber;
    this.router.navigate(['/Product']);
  }
}
