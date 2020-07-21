import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ShopParams } from '../shared/models/shopParams';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IPagination } from '../shared/models/pagination';
import { map, delay } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  baseUrl = 'https://localhost:5001/api/';


  constructor(private http: HttpClient) { }
  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }
  getBrand(id: number) {
    return this.http.get<IBrand>(this.baseUrl + 'brand/' + id);
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

}
