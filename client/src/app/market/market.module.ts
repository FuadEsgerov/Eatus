import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarketComponent } from './market.component';
import{ProductBrandComponent} from '../restaurant/product-brand/product-brand.component'
import { SharedModule } from '../shared/shared.module';
import{RestaurantModule}from '../restaurant/restaurant.module'

@NgModule({
  declarations: [MarketComponent,ProductBrandComponent],
  imports: [
    CommonModule,
SharedModule,
RestaurantModule
  ],
  exports:[MarketComponent,ProductBrandComponent]
})
export class MarketModule { }
