import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  isHome: boolean;

  stepCup: string;

  msgBanner: string;

  constructor(router: Router) {
    this.isHome = false;
    this.stepCup = '';
    this.msgBanner = '';
    router.events.subscribe(
      (event) => {
        if (event instanceof NavigationStart){
          this.isHome = (event.url.indexOf('teams') > -1);
          this.updateMaster();
        }
      });
  }

  ngOnInit() {
  }

  updateMaster(): void {
    this.stepCup = (this.isHome ? 'Fase de Seleção' : 'Resultado Final');
    this.msgBanner = (this.isHome ?
      'Selecione 8 equipes que você deseja para a competição e depois pressione o botão GERAR COPA para prosseguir.' :
      'Veja o resultado final da Copa de forma simples e rápida');
  }
}
