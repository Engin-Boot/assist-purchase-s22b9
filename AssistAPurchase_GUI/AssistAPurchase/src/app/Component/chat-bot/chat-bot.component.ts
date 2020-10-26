import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { from, Observable } from 'rxjs';
import { RespondToQuestionService } from 'src/app/Controller/respond-to-question.service';
import { CustomFilter } from 'src/app/DataModel/CustomFilter';
import { GetAllProduct } from 'src/app/DataModel/GetAllProduct';

@Component({
  selector: 'app-chat-bot',
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css']
})
export class ChatBotComponent implements OnInit {

  hello = '';
  name = '';
  email = '';
  noPreference = "NOPreference";

  ishelloCustomer = true;
  isProductFilterd = false;
  isReplied = false;
  isEmailEntered = false;
  isUpdateSupportNeeded = false;
  isPortabilityNeeded = false;
  isBatterySupport = false;
  isMultiPatientSupport = false;
  isTouchScreenSupportNeeded = false;
  isWearable = false;
  thankYou = false;
  thankYouSendMail = false;
  isMailed = false;
  isDisplayed = false;

  productName = [];
  static filterDetail: CustomFilter[] = [];
  static filterCount = 0;
  FilteredProduct: GetAllProduct[] = [];
  iterator = 0;

  constructor(private responce : RespondToQuestionService) { }

  ngOnInit(): void {
    this.InsertProductName();
  }

  HelloBot(){
    this.isReplied = true;
    this.hello = "Hello";
    this.ishelloCustomer = false;
  }
 
  Filter(){
    this.isProductFilterd = true;
  }

  FilterProduct(catergory: string,filter : string){
    let filterObj = new CustomFilter();
    filterObj.category = catergory;
    filterObj.filter = filter;
    ChatBotComponent.filterDetail.push(filterObj);
  }

  SelectedProduct(selectedProduct : string){
    this.isReplied = false;
    this.isWearable = true;
    if(selectedProduct != "All Products")
    this.FilterProduct("ProductName",selectedProduct);
  }
  IsWearable(wearable: string){
    this.isWearable = false;
    this.isMultiPatientSupport = true;
    if( wearable != this.noPreference)
    this.FilterProduct("Wearable",wearable);
  }
  IsMultiPatientSupport(multiPatientSetup: string){
    this.isMultiPatientSupport = false;
    this.isUpdateSupportNeeded = true;
    if(multiPatientSetup != this.noPreference)
    this.FilterProduct("MultiPatientSupport",multiPatientSetup);
  }
  IsUpdateSupportNeeded(updateSupport : string){
    this.isUpdateSupportNeeded = false;
    this.isPortabilityNeeded = true;
    if(updateSupport != this.noPreference)
    this.FilterProduct("SoftwareUpdateSupport",updateSupport);
  }
  IsProtabilitySupportNeeded(portabilitySupport : string){
    this.isPortabilityNeeded = false;
    this.isBatterySupport = true;
    if(portabilitySupport != this.noPreference)
    this.FilterProduct("Portability",portabilitySupport)
  }
  IsBatterySupportNeeded(batterySupport : string){
    this.isBatterySupport = false;
    this.isTouchScreenSupportNeeded = true;
    if(batterySupport != this.noPreference)
    this.FilterProduct("BatterySupport",batterySupport);
  }
  IsTouchScreenSupportNeeded(touchScreenSupport : string){
    this.isTouchScreenSupportNeeded = false;
    this.isDisplayed = true;
    this.thankYou = true;
    if(touchScreenSupport != this.noPreference)
    this.FilterProduct("TouchScreenSupport",touchScreenSupport);
    this.ApplyFilter();
  }
 
  SetInput(input: string){
    if(this.isProductFilterd == true){
      this.name = input;
      this.isEmailEntered = true;
      this.isProductFilterd = false
    }
    else if(this.isEmailEntered == true){
      this.isProductFilterd = false;
      this.email = input;
      this.thankYouSendMail = true;
    }
  }
  ThankUser(){
      location.reload();
  }
  InsertProductName(){
    this.productName[0] = "IntelliVue";
    this.productName[1] = "Efficia";
    this.productName[2] = "Goldway";
    this.productName[3] = "All Products";
  }

  ApplyFilter(){
    let data = new Map();
    let body = {};
    var category;
    var filter;
    
    for(this.iterator = 0; this.iterator < ChatBotComponent.filterDetail.length; this.iterator++){
      data.set(ChatBotComponent.filterDetail[this.iterator].category , ChatBotComponent.filterDetail[this.iterator].filter);
    } 
    data.forEach((value, key) => {  
      body[key] = value  
  });
    let observable=this.responce.GetSpecificProduct(body);
    observable.subscribe((result:GetAllProduct[])=>{
      this.FilteredProduct = result;
      console.log(result);
    },
    (error:any)=>{
     alert("Internal Error");
    },
    ()=>{
      console.log("Completed");
    });
  }
}
