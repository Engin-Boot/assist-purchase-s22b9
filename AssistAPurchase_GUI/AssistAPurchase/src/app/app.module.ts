import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms' 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from 'src/app/Component/admin/admin.component';
import { ProductManagementService } from 'src/app/Controller/product-management.service';
import { RespondToQuestionService } from 'src/app/Controller/respond-to-question.service';
import { AdminLoginService } from 'src/app/Controller/admin-login.service';
import { HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';
import { HomeComponent } from './Component/home/home.component';
import { LoginComponent } from './Component/login/login.component';
import { ChatBotComponent } from './Component/chat-bot/chat-bot.component';
import { ViewProductComponent } from './Component/view-product/view-product.component';
import { PersonnalSupportComponent } from './Component/personnal-support/personnal-support.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    HomeComponent,
    LoginComponent,
    ChatBotComponent,
    ViewProductComponent,
    PersonnalSupportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ProductManagementService, RespondToQuestionService, AdminLoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
