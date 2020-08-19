import { Component, OnInit } from '@angular/core';
import { FaqService } from './faq.service';
import { IFaq } from '../shared/models/faq';
@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FaqComponent implements OnInit {
  faqs: IFaq[];
  constructor(private faqService: FaqService) { }

  ngOnInit() {
    this.getFaq();
  }

  getFaq() {
    this.faqService.getFaqs().subscribe(response => {
      this.faqs = [ ...response];
    }, error => {
      console.log(error);
    });
  }
}
