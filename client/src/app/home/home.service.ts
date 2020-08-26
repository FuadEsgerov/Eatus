import { Injectable } from '@angular/core';
import {IBrand} from '../shared/models/brand'
import { IBrandList } from '../shared/models/category';
import { IType } from '../shared/models/department';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ISlider } from '../shared/models/slider';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  getType(id:number) {
    return this.http.get<IType>(this.baseUrl + id );
  }
  getSlider(){
    return this.http.get<ISlider>(this.baseUrl + "slider" );
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'categories');
  }

  getBrand(brandid:number,shopParams:ShopParams) {
    let params = new HttpParams();
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    return this.http.get<IBrandList>(this.baseUrl + 'category/'+ brandid,{ observe: 'response', params }) .pipe(
      map(response => {
        return response.body;
      })
    );
  }
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();


    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }
}
