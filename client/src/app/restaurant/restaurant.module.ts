import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantComponent } from './restaurant.component';
import{ProductBrandComponent}from './product-brand/product-brand.component';
import { SharedModule } from '../shared/shared.module';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { BrandComponent } from './brand/brand.component';
import { BrandItemComponent } from './brand-item/brand-item.component';



@NgModule({
  declarations: [RestaurantComponent,ProductBrandComponent,BrandComponent,BrandItemComponent],
  imports: [
    CommonModule,
    SharedModule,
    RestaurantRoutingModule
  ]
})
export class RestaurantModule { }
