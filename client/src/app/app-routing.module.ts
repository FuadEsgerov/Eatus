import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AuthGuard } from './core/guard/auth.guard';
import {MarketComponent} from './market/market.component';
import {RestaurantModule} from './restaurant/restaurant.module';


const routes: Routes = [
  {path:'', component:HomeComponent,data: { breadcrumb: 'Ana Səhifə' }},
  {path:'shop',loadChildren:()=>import('./shop/shop.module').then(mod=>mod.ShopModule),data: { breadcrumb: 'Məhsullar' }},
  {path:'restaurant',loadChildren:()=>import('./restaurant/restaurant.module').then(mod=>mod.RestaurantModule),data: { breadcrumb: 'Məhsullar' }},
  {path:'market', component:MarketComponent,data: { breadcrumb: 'Ana Səhifə' }},
  {path:'basket',loadChildren:()=>import('./basket/basket.module').then(mod=>mod.BasketModule),data: { breadcrumb: 'Səbət' }},
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module')
      .then(mod => mod.CheckoutModule), data: { breadcrumb: 'Checkout' }
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module')
      .then(mod => mod.OrdersModule), data: { breadcrumb: 'Orders' }
  },

  {
    path: 'account', loadChildren: () => import('./account/account.module')
      .then(mod => mod.AccountModule), data: { breadcrumb: { skip: true } }
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
