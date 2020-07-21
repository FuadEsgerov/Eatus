import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { RestaurantService } from '../restaurant.service';
import { ShopParams } from 'src/app/shared/models/shopParams';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.scss']
})
export class BrandComponent implements OnInit {
  products: IProduct[];
  shopParams = new ShopParams();
  totalCount: number;
  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {

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
