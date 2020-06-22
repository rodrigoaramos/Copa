import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { HttpWrapper } from './shared/http/httpwrapper';
import { AppRoutingModule } from './components/home/home-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './components/home/home.component';
import { TeamsComponent } from './components/teams/teams.component';
import { FinalComponent } from './components/final/final.component';

@NgModule({
  declarations: [
    HomeComponent,
    TeamsComponent,
    FinalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatGridListModule,
    MatCardModule,
    MatCheckboxModule,
    MatSnackBarModule
  ],
  providers: [HttpClient, HttpWrapper],
  bootstrap: [HomeComponent]
})
export class AppModule { }
