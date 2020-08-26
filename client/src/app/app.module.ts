import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import {NgxSpinnerModule} from 'ngx-spinner';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { FaqComponent } from './faq/faq.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { OurTeamComponent } from './ourteam/ourteam.component';


@NgModule({
  declarations: [
    AppComponent,
    RestaurantComponent,
    FaqComponent,
   OurTeamComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    NgxSpinnerModule,
    MatDialogModule,
    CarouselModule,


  ],

  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent],
  entryComponents: [ProductDetailsComponent]
})
export class AppModule { }
