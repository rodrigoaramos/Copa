import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LanguageSelector } from './../../shared/localization/lang-selector';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TeamcupService } from '../../services/teamcup.service';
import { Team } from './../../models/entities/team-entity';
import { CupResultTransport } from './../../models/transport/cupresult-transport';

const messages = LanguageSelector.getActiveLanguage();

const MAX_TEAMS = 8;

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  teams: Team[];

  selecteds: number;

  constructor(private router: Router, private service: TeamcupService, private snackBar: MatSnackBar) {
    this.selecteds = 0;
  }

  ngOnInit(): void {
    this.getTeams();
  }

  showSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 3000,
      verticalPosition: 'top',
      panelClass: ['mat-toolbar', 'mat-warn']
    });
  }

  getTeams(): void {
    this.service.getTeams()
      .subscribe((teams: Team[]) => {
        this.teams = teams;
      });
  }

  onChangeState(event: MatCheckboxChange, index: number): void {
    this.selecteds = this.countTeams();
    if (event.checked){
      if ((this.selecteds + 1) > MAX_TEAMS) {
        event.source.checked = false;
        this.showSnackBar(messages.teamcup.msg100, messages.teamcup.txt11);
        return;
      }
      this.selecteds++;
      this.teams[index].checked = true;
    }
    else {
      if ((this.selecteds - 1) < 0) {
        event.source.checked = true;
        return;
      }
      this.selecteds--;
      this.teams[index].checked = false;
    }
  }

  countTeams(): number {
    return this.teams.filter(x => x.checked).length;
  }

  startGames(): void {
    const selecteds = this.teams.filter(x => x.checked);
    this.service.doGamming(selecteds)
      .subscribe((transp: CupResultTransport) => {
        console.log('---------> First: ' + transp.first.id);
        this.router.navigate(['/final', { first: transp.first.name, second: transp.second.name }]);
      });
  }

  onGenClick(): void {
    if (this.selecteds !== MAX_TEAMS) {
      this.showSnackBar(messages.teamcup.msg101, messages.teamcup.txt11);
    }
    this.startGames();
  }
}
