import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SharedModule } from '../shared/shared.module';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { HomeRoutingModule } from './home-routing.module';
import { CategoryComponent } from './category/category.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { BasketModule } from '../basket/basket.module';
import { ProductItemComponent } from './restaurant/product-item/product-item.component';






@NgModule({
  declarations: [HomeComponent,CategoryComponent, RestaurantComponent, ProductItemComponent],
  imports: [
    CommonModule,
    SharedModule,
    CarouselModule,
    HomeRoutingModule,
    BasketModule,
  ],


})
export class HomeModule { }
