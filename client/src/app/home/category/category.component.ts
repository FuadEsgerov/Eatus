import { Component, OnInit, Input } from '@angular/core';
import { IBrand } from '../../shared/models/brand';
import { IType } from 'src/app/shared/models/department';
import { HomeService } from '../home.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  @Input() type: IType;
  product:IProduct;


  constructor(private homeService: HomeService,
    private activateRoute: ActivatedRoute,) { }

  ngOnInit() {
    this.loadBrand();
  }

  loadBrand() {
    this.homeService.getType(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(brand => {

    this.type=brand;
    }, error => {
      console.log(error);
    });
  }
}
