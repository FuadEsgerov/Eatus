import { Component, OnInit,Input } from '@angular/core';
import { IBrand } from 'src/app/shared/models/brand';
import { RestaurantService } from '../restaurant.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-brand-item',
  templateUrl: './brand-item.component.html',
  styleUrls: ['./brand-item.component.scss']
})
export class BrandItemComponent implements OnInit {
  @Input() product: IProduct;

  constructor() { }

  ngOnInit(): void {

  }

 
}
