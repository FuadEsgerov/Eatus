import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarketComponent } from './market.component';



@NgModule({
  declarations: [MarketComponent],
  imports: [
    CommonModule
  ],
  exports:[MarketComponent]
})
export class MarketModule { }
