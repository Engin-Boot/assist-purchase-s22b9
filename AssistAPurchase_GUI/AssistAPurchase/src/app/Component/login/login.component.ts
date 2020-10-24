import { Component, OnInit } from '@angular/core';
import { AdminLoginService } from 'src/app/Controller/admin-login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isValid = false;
  constructor(private adminLogin : AdminLoginService, private router: Router) { }

  ngOnInit(): void {
  }

  ValidateCredentials(email: string , password: string){
    console.log(email + password);
    let data = {email: email, password: password};
    let observable=this.adminLogin.ValidateAdmin(data);
    observable.subscribe((data:Response)=>{
      this.isValid = true;
    },
    (error:any)=>{
      this.isValid = false;
     alert("Invalid Credentials");
    },
    ()=>{
      console.log("Completed");
    });

    if( this.isValid){
      this.router.navigate(['/admin']);
    }
  }

  GoBacKToHome(){
    this.router.navigate(['/Home']);
  }
}
