import { Component, OnInit } from '@angular/core';
import { ContactCustomer } from 'src/app/DataModel/ContactCustomer'
import {RespondToQuestionService} from 'src/app/Controller/respond-to-question.service'
@Component({
  selector: 'app-personnal-support',
  templateUrl: './personnal-support.component.html',
  styleUrls: ['./personnal-support.component.css']
})
export class PersonnalSupportComponent implements OnInit {

   cutomerInfo: ContactCustomer;

  constructor(
     
    private emailController: RespondToQuestionService
    
  ) { }
  ngOnInit(): void {
    this.cutomerInfo = new ContactCustomer();
    // cutomerInfo: ContactCustomer;
  }

  SendEmail(invalid: boolean): void {
    
    if (invalid) {
      alert("Please enter the required details")
      return;
    }
    let data = {"CustomerName": this.cutomerInfo.CustomerName,
                "CustomerEmailId": this.cutomerInfo.CustomerEmailId,
                "ProductName": this.cutomerInfo.ProductName,
                "Mobile": this.cutomerInfo.Mobile
    };
    let observable = this.emailController.SendEmailToPersonal(data)
    observable.subscribe((data: Response) => {
    
    },
      (error: any) => {
        //alert(error);
        
        alert("Unable to send email" );
      },
      () => {
        console.log("Completed");
        alert("Thank you. Our Sales till will contact you shortly.");
        window.location.reload();
      });
    
  }

}

