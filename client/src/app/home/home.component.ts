import { Component, OnInit,Input } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import {HomeService} from "./home.service"

export interface IBrand {
  id: number;
  name: string;
  image: string;
  address: string;


}
export interface IType {
  id: number;
  name: string;
  image: string;

}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {
  brands: IBrand[];
  types: IType[];
  type:IType;
  brand:IBrand;
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: true,
    pullDrag: true,
    dots: true,
    margin:25,
    autoHeight:true,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      1000: {
        items: 4
      }

    },
    nav: true
  }
  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.getBrands();
    this.getTypes();

  }
  getBrands() {
    this.homeService.getBrands().subscribe(response => {
      this.brands = [ ...response];
    }, error => {
      console.log(error);
    });
  }
  getTypes() {
    this.homeService.getTypes().subscribe(response => {
      this.types = [ ...response];
    }, error => {
      console.log(error);
    });
  }
}
