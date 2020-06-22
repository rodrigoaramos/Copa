import { Team } from '../entities/team-entity';

export class CupResultTransport {

  first: Team;
  second: Team;

  constructor(first: Team, second: Team) {
     this.first = first;
     this.second = second;
  }
}
