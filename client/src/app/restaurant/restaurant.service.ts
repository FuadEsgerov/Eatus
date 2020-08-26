import { Injectable } from '@angular/core';
import {IBrand} from '../shared/models/brand'
import { IBrandList } from '../shared/models/category';
import { IType } from '../shared/models/department';
import { HttpClient, HttpParams } from '@angular/common/http';

import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  baseUrl = environment.apiUrl;;

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
  getBrand(id:number) {
    return this.http.get<IBrandList>(this.baseUrl + 'category/'+ id);
  }


}
