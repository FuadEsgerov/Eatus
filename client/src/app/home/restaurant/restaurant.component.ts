import { Component, OnInit,Input } from '@angular/core';
import { HomeService } from '../home.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { IBrand } from 'src/app/shared/models/brand';
import { BasketService } from 'src/app/basket/basket.service';
import { IBrandList } from 'src/app/shared/models/category';
import { IBasketItem } from 'src/app/shared/models/basket';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { IType } from 'src/app/shared/models/productType';
import { ShopParams } from 'src/app/shared/models/shopParams';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {
  shopParams = new ShopParams();
  brandlist: IBrandList;
   types :IType[];

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: false,
    margin:25,
    autoHeight:true,
    navSpeed: 600,
    navText: ["<i class='fa fa-long-arrow-left'></i>","<i class='fa fa-long-arrow-right'></i>"],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      768: {
        items: 5
      },
      1000: {
        items: 6
      }

    },
    nav: true
  }



  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,
    private basketService: BasketService,) { }

  ngOnInit() {
    this.loadProduct();
    this.getTypes();
  }
  getTypes() {
    this.homeService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All',image:'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }
  loadProduct() {
    this.homeService.getBrand( +this.activateRoute.snapshot.paramMap.get('id'),this.shopParams).subscribe(response => {

    this.brandlist=response;
    }, error => {
      console.log(error);
    });
  }
  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.loadProduct();
  }

  addItemToBasket(item: IBrandList) {
    this.basketService.addItemToBasket(item.products);
    ;
  }

}
