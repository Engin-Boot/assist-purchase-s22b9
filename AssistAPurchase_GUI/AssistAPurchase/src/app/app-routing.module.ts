import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { AdminComponent } from 'src/app/Component/admin/admin.component';
import { HomeComponent } from 'src/app/Component/home/home.component';
import { LoginComponent } from 'src/app/Component/login/login.component';
import { ChatBotComponent } from 'src/app/Component/chat-bot/chat-bot.component';
import { ViewProductComponent } from 'src/app/Component/view-product/view-product.component';

const routes: Routes = [
  {path:'admin', component: AdminComponent},
  {path: 'Home', component: HomeComponent},
  {path: 'Login', component: LoginComponent},
  {path: 'ChatBot', component: ChatBotComponent},
  {path: 'Product', component:ViewProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
