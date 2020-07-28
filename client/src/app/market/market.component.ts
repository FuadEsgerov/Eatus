import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { MarketService } from './market.service';
@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.scss']
})
export class MarketComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopParams = new ShopParams();
  constructor(private marketService: MarketService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  getProducts() {
    this.marketService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;

    }, error => {
      console.log(error);
    });
  }

  getBrands() {
    this.marketService.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All',image:'All',address:'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.marketService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All',image:'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }



}
