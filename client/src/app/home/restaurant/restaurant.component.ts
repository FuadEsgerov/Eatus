import { Component, OnInit,Input } from '@angular/core';
import { HomeService } from '../home.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { IBrand } from 'src/app/shared/models/brand';
import { BasketService } from 'src/app/basket/basket.service';
import { IBrandList } from 'src/app/shared/models/category';
import { IBasketItem } from 'src/app/shared/models/basket';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  brandlist: IBrandList;




  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,
    private basketService: BasketService,) { }

  ngOnInit() {
    this.loadProduct();
  }
  loadProduct() {
    this.homeService.getBrand(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(response => {

    this.brandlist=response;
    }, error => {
      console.log(error);
    });
  }

  addItemToBasket(item: IBrandList) {
    this.basketService.addItemToBasket(item.products);
    ;
  }

}
