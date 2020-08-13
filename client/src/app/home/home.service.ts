import { Injectable } from '@angular/core';
import {IBrand} from '../shared/models/brand'
import { IBrandList } from '../shared/models/category';
import { IType } from '../shared/models/department';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IProduct } from '../shared/models/product';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  getType(id:number) {
    return this.http.get<IType>(this.baseUrl + id );
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'categories');
  }
  getBrand(brandid:number) {
    return this.http.get<IBrandList>(this.baseUrl + 'category/'+ brandid);
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
