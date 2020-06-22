import { ITeam } from '../contracts/team-interface';

export class Team implements ITeam {

  id: string;
  name: string;
  initials: string;
  goals: number;
  checked: boolean;

  constructor(id: string, name: string, initials: string, goals: number, checked: boolean) {
     this.id = id || '';
     this.name = name || '';
     this.initials = initials || '';
     this.goals = goals || 0;
     this.checked = checked || false;
  }
}
