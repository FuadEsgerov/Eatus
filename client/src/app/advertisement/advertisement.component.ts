import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from './advertisement.service';
import { IAdvertisement } from '../shared/models/advetisement';

@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.scss']
})
export class AdvertisementComponent implements OnInit {
  ads: IAdvertisement[];
  constructor(private adsService: AdvertisementService) { }

  ngOnInit() {
    this.getAds();
  }

  getAds() {
    this.adsService.getAds().subscribe(response => {
      this.ads = [ ...response];
    }, error => {
      console.log(error);
    });
  }

}
