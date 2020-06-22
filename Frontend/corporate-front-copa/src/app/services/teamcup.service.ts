import { Injectable } from '@angular/core';
import { ApiConstants } from './../shared/http/apiconstants';
import { Observable } from 'rxjs';
import { catchError, tap, map, retry } from 'rxjs/operators';
import { HttpWrapper } from './../shared/http/httpwrapper';
import { Team } from './../models/entities/team-entity';
import { TeamTransport } from './../models/transport/teams-transport';
import { CupResultTransport } from './../models/transport/cupresult-transport';

@Injectable({
  providedIn: 'root'
})
export class TeamcupService {

  constructor(private wrapper: HttpWrapper) { }

  getTeams(): Observable<Team[]> {
    return this.wrapper.post(ApiConstants.ALL_TEAMS, null)
      .pipe(
        retry(2),
        catchError(this.wrapper.handleError('getTeams', {})));
  }

  doGamming(teams: Team[]): Observable<CupResultTransport> {
    const transp = new TeamTransport(teams);
    return this.wrapper.post(ApiConstants.DO_GAMMING, transp)
      .pipe(
        retry(2),
        catchError(this.wrapper.handleError('doGamming', {})));
  }
}
