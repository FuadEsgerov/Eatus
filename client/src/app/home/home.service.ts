import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/department';
import { HttpClient, HttpParams } from '@angular/common/http';
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
}
