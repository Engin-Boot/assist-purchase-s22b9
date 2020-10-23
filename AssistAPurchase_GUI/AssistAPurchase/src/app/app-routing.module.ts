import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { AdminComponent } from 'src/app/Component/admin/admin.component';
import { HomeComponent } from 'src/app/Component/home/home.component';

const routes: Routes = [
  {path:'admin', component: AdminComponent},
  {path: 'Home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
