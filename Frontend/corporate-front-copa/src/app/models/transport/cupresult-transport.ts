import { Team } from '../entities/team-entity';

export class CupResultTransport {

  first: Team;
  second: Team;
  error: boolean;
  msgError: string;

  constructor(first: Team, second: Team, error: boolean, msgError: string) {
     this.first = first;
     this.second = second;
     this.error = error;
     this.msgError = msgError || '';
  }
}
