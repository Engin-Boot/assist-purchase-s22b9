import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { AdminComponent } from 'src/app/Component/admin/admin.component';
import { HomeComponent } from 'src/app/Component/home/home.component';
import { LoginComponent } from 'src/app/Component/login/login.component';
import { ChatBotComponent } from 'src/app/Component/chat-bot/chat-bot.component';
import { ViewProductComponent } from 'src/app/Component/view-product/view-product.component';
import { PersonnalSupportComponent } from './Component/personnal-support/personnal-support.component';

const routes: Routes = [
  {path:'admin', component: AdminComponent},
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'chatBot', component: ChatBotComponent},
  {path: 'product', component:ViewProductComponent},
  {path: 'contact', component:PersonnalSupportComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
