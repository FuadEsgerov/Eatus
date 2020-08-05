import { Component, OnInit,Input } from '@angular/core';
import { RestaurantService } from './restaurant.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { BasketService } from 'src/app/basket/basket.service';
import { IBrandList } from 'src/app/shared/models/category';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  brandlist: IBrandList;
  product:IProduct



  constructor(private resService: RestaurantService,
    private activateRoute: ActivatedRoute,
    private basketService: BasketService) { }

  ngOnInit() {
    this.loadProduct();
  }
  loadProduct() {
    this.resService.getBrand(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(response => {

    this.brandlist=response;
    }, error => {
      console.log(error);
    });
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }
}
