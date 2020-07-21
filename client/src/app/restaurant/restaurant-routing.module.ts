import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantComponent } from './restaurant.component';
import { BrandComponent } from './brand/brand.component';
import { BrandItemComponent } from './brand-item/brand-item.component';


const routes: Routes = [
  {path: '', component: RestaurantComponent},
  {path: ':id', component: BrandComponent, data: {breadcrumb: {alias: 'productDetails'}}},

];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
