import { Injectable } from '@angular/core';
import { IAbout } from '../shared/models/about';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AboutService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAbout(){
    return this.http.get<IAbout[]>(this.baseUrl + 'about');
  }
}
