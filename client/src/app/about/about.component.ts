import { Component, OnInit } from '@angular/core';
import { AboutService } from './about.service';
import { IAbout } from '../shared/models/about';
@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {

  about: IAbout[];
  constructor(private aboutService: AboutService) { }

  ngOnInit() {
    this.getAbout();
  }

  getAbout() {
    this.aboutService.getAbout().subscribe(response => {
      this.about = [ ...response];
    }, error => {
      console.log(error);
    });
  }

}
