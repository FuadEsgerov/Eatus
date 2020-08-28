import { Injectable } from '@angular/core';
import { IOurTeam } from '../shared/models/ourteam';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OurteamService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTeams(){
    return this.http.get<IOurTeam[]>(this.baseUrl + 'ourteam');
  }
}
