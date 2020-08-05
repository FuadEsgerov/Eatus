import { Component, OnInit,Input } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import {HomeService} from "./home.service"
import { IProduct } from '../shared/models/product';
import { ShopParams } from '../shared/models/shopParams';
import { BasketService } from '../basket/basket.service';

export interface IBrand {
  id: number;
  name: string;
  image: string;
  address: string;


}
export interface IType {
  id: number;
  name: string;
  image: string;

}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {
  brands: IBrand[];
  types: IType[];
  type:IType;
  brand:IBrand;
  product :IProduct;
  products:IProduct[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: true,
    margin:25,
    autoHeight:true,
    navSpeed: 700,
    navText: ["<i class='fa fa-long-arrow-left'></i>","<i class='fa fa-long-arrow-right'></i>"],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      1000: {
        items: 4
      }

    },
    nav: true
  }
  constructor(private homeService: HomeService,
    private basketService: BasketService) { }

  ngOnInit() {
    this.getBrands();
    this.getTypes();
    this.getProducts();

  }
  getProducts() {
    this.homeService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }
  getBrands() {
    this.homeService.getBrands().subscribe(response => {
      this.brands = [ ...response];
    }, error => {
      console.log(error);
    });
  }
  getTypes() {
    this.homeService.getTypes().subscribe(response => {
      this.types = [ ...response];
    }, error => {
      console.log(error);
    });
  }
}
