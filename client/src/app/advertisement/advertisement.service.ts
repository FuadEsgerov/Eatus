import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { IAdvertisement } from '../shared/models/advetisement';
@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAds(){
    return this.http.get<IAdvertisement[]>(this.baseUrl + 'advertisement');
  }
}
