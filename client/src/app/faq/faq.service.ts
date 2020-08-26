import { Injectable } from '@angular/core';
import { IFaq } from '../shared/models/faq';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class FaqService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getFaqs(){
    return this.http.get<IFaq[]>(this.baseUrl + 'faqs');
  }
}
