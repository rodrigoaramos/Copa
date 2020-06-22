import { Team } from '../entities/team-entity';

export class TeamTransport {

  teams: Team[];

  constructor(teams: Team[]) {
     this.teams = teams || [];
  }
}
