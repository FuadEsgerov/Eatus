import { Injectable } from '@angular/core';
import { IFaq } from '../shared/models/faq';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class FaqService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  getFaqs(){
    return this.http.get<IFaq[]>(this.baseUrl + 'faqs');
  }
}
