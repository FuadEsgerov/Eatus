import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import{CategoryComponent} from './category/category.component'
import { HomeComponent } from './home.component';
import { RestaurantComponent } from './restaurant/restaurant.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: ':id', component: CategoryComponent},
  {path: ':id/:id', component: RestaurantComponent},

];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
   exports: [RouterModule]
})
export class HomeRoutingModule { }
