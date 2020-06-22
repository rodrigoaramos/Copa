import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './../home/home.component';
import { TeamsComponent } from '../teams/teams.component';
import { FinalComponent } from './../final/final.component';

const routes: Routes = [
  { path: 'teams', component: TeamsComponent },
  { path: 'final', component: FinalComponent },
  { path: '', redirectTo: '/teams', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
