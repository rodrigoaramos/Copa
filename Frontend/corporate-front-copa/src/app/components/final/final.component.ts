import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LanguageSelector } from './../../shared/localization/lang-selector';

const messages = LanguageSelector.getActiveLanguage();

@Component({
  selector: 'app-final',
  templateUrl: './final.component.html',
  styleUrls: ['./final.component.css']
})
export class FinalComponent implements OnInit {

  first: string;
  second: string;

  constructor(private actRoute: ActivatedRoute) {
    this.first = '';
    this.second = '';
  }

  ngOnInit(): void {
    this.actRoute.paramMap.subscribe(params => {
      this.first = params.get('first');
      this.second = params.get('second');
    });
  }
}
