import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { RestaurantService } from './restaurant.service';
import { IProduct } from '../shared/models/product';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {
  brands: IBrand[];
  products: IProduct[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];


  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.getBrands();
    this.getProducts();


  }
  getBrands() {
    this.restaurantService.getBrands().subscribe(response => {
      this.brands = [ ...response];
    }, error => {
      console.log(error);
    });
  }

  getProducts() {
    this.restaurantService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

}
