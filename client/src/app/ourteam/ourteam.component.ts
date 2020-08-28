import { Component, OnInit } from '@angular/core';
import { OurteamService } from './ourteam.service';
import { IOurTeam } from '../shared/models/ourteam';
@Component({
  selector: 'app-ourteam',
  templateUrl: './ourteam.component.html',
  styleUrls: ['./ourteam.component.scss']
})
export class OurTeamComponent implements OnInit {

  teams: IOurTeam[];
  constructor(private teamService: OurteamService) { }

  ngOnInit() {
    this.getTeam();
  }

  getTeam() {
    this.teamService.getTeams().subscribe(response => {
      this.teams = [ ...response];
    }, error => {
      console.log(error);
    });
  }

}
