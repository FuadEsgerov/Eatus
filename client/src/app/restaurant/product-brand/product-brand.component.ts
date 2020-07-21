import { Component, OnInit,Input } from '@angular/core';
import { IBrand } from 'src/app/shared/models/brand';
@Component({
  selector: 'app-product-brand',
  templateUrl: './product-brand.component.html',
  styleUrls: ['./product-brand.component.scss']
})
export class ProductBrandComponent implements OnInit {

@Input() brand: IBrand;

  constructor() { }

  ngOnInit(): void {
  }

}
