import { Component } from '@angular/core';
import { ApplicationServerService } from 'src/app/Service/application-server.service';
import { GetAllProductInfo } from 'src/app/DataCollector/GetAllProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public getAllProductInfo = [];

  constructor (private productInfo: ApplicationServerService) {}

  ngOnInit(): void {
    this.productInfo.getProductInfo().subscribe(data => this.getAllProductInfo = data);
  }

  GetAllProductInfo(){
    
  }
}
