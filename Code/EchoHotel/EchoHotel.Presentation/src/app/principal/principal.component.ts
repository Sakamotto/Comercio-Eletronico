import { Component, OnInit, AfterContentInit } from '@angular/core';
import { Http, Headers, RequestOptions, Jsonp } from '@angular/http';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';

import { AppConfig } from '../app.config';

declare var $: any;
declare var mycallback: any;

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit, AfterContentInit {
  constructor(
    private http: Http,
    private jsonp: Jsonp,
    private router: Router
  ) {}

  private filtros: any;
  private options: Array<any>;
  private dataTermino: string;
  private dataInicio: string;
  private optionSelected: any;
  private guests;

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
      }
    });
  }

  ngOnInit() {
    let parametros: URLSearchParams = new URLSearchParams();
    let myHeaders: Headers = new Headers();

    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Accept', 'application/json');
    parametros.append('callback', 'mycallback');

    // myHeaders.append('Access-Control-Allow-Methods', 'POST');
    // myHeaders.append('Authorization', 'CorrectHorseBatteryStaple');
    // myHeaders.append('Access-Control-Allow-Origin', '*');

    // let options: RequestOptions = new RequestOptions({headers: myHeaders});

    this.http.get(AppConfig.BASE_URL + '/hotel/ObterCarros')
    // .map(data => data.json())
    .subscribe(data => {
      let strJson: string = data.json();
      console.log('Here is the data: ', JSON.parse(strJson));
    });

    // this.jsonp.request('http://topgearapi.azurewebsites.net/api/carro?callback=JSONP_CALLBACK').
    // subscribe(data => {
    //   console.log('Here is the data: ', data.json());
    // }, error => console.log('Erro: ', error));

    this.http.get('http://localhost:52401/api/endereco').
    subscribe((data) => {
      this.options = this.filtro(data.json());
      console.log('Dados: ', this.options);
    });
  }

  mycallback(data) {
    console.log('asdasdasd: ', data);
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
    console.log('filtros: ', this.dataInicio);
    this.filtros = {
      dataInicio: this.dataInicio,
      dataTermino: this.dataTermino,
      enderecoId: this.optionSelected.Id,
      cidade: this.optionSelected.Cidade,
      guests: this.guests
    };
    console.log('filtros: ', this.filtros, this.dataInicio);
    this.router.navigate(['/hoteis'], {queryParams: this.filtros});
  }

}
