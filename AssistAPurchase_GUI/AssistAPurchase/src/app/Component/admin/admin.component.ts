import { Component, OnInit } from '@angular/core';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  form: FormGroup;
  public prodDetail = [];
  public index : number;
  constructor(private productDetail: ProductManagementService) { }

  ngOnInit(): void {
    this.productDetail.GetProductInfo().subscribe(data => this.prodDetail = data);
    console.log(this.prodDetail.length);
  }

  GetAllProductInformation(): void{
    /*for(this.index = 0; this.index < this.prodDetail.length; this.index++){
      console.log("i am inside");
      console.log(this.prodDetail[this.index]);
    }*/
  }
}
