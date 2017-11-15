import { Component, OnInit, AfterContentInit } from '@angular/core';
import { Http, Headers, RequestOptions, Jsonp } from '@angular/http';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';

import { AppConfig } from '../app.config';
import { HotelService } from '../hotel/hotel.service';
import { UtilService } from '../shared/util.service';

declare var $: any;
declare var mycallback: any;

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css'],
  providers: [HotelService, UtilService]
})
export class PrincipalComponent implements OnInit, AfterContentInit {
  constructor(
    private http: Http,
    private jsonp: Jsonp,
    private router: Router,
    private hotelService: HotelService,
    private utilService: UtilService
  ) {}

  private filtros: any;
  public options: Array<any>;
  private dataTermino: string;
  private dataInicio: string;
  private optionSelected: any;
  public guests = 1;
  public showSpinner = true;

  myControl: FormControl = new FormControl();

  ngAfterContentInit(): void {
    // tslint:disable:prefer-const
    let _this = this;

    $('#dtInicio').datepicker({
      dateFormat: 'dd/mm/yy',
      onSelect: function (dataText, inst) {
        let split = dataText.split('/');
        _this.dataInicio = new Date(split[2], split[1] - 1, split[0]).toISOString();
        console.log(_this.dataInicio);
      }
    });

    $('#dtTermino').datepicker({
      dateFormat: 'dd/mm/yy',
      onSelect: function (dataText, inst) {
        let split = dataText.split('/');
        _this.dataTermino = new Date(split[2], split[1] - 1, split[0]).toISOString();
        console.log(_this.dataTermino);
      }
    });

    // let reqParams = new URLSearchParams();

    // this.http.get(AppConfig.BASE_URL + '/hotel/ObterCarrosDisponiveis')
    // .subscribe(data => {
    //   console.log('Carros disponíveis: ', data);
    //   console.log('[Json] Carros disponíveis: ', data.json());
    // });

  }

  ngOnInit() {
    this.http.get(AppConfig.BASE_URL + '/endereco').
    subscribe((data) => {
      this.options = this.filtro(data.json());
      this.showSpinner = false;
    }, (error) => this.showSpinner = false);
  }

  private filtro(dados: Array<any>) {
    let retorno: Array<any> = [];

    dados.forEach((item, pos) => {
      if ( !(this.in(item, retorno)) ) {
        retorno.push(item);
      }
    });
    return retorno;
  }

  private in(item: any, dados: Array<any>): boolean {
    for (let i = 0; i < dados.length; i++) {
      if (dados[i].Cidade === item.Cidade) {
        return true;
      }
    }
    return false;
  }

  selected(option) {
    this.optionSelected = option;
  }

  buscarHoteis() {
    this.filtros = {
      dataInicio: this.dataInicio,
      dataTermino: this.dataTermino,
      enderecoId: this.optionSelected.Id,
      cidade: this.optionSelected.Cidade,
      guests: this.guests
    };
    this.router.navigate(['/hoteis'], {queryParams: this.filtros});
  }

  onChange() {
    let mySelect: any = document.getElementById('comboGuests');
    let selecionado = mySelect.options[mySelect.selectedIndex].value;
    this.guests = selecionado;
  }

}
