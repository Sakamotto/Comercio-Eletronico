import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http, URLSearchParams, RequestOptions, RequestOptionsArgs, Headers } from '@angular/http';
import { MatSnackBar } from '@angular/material';
import { ToastsManager } from 'ng2-toastr';

import { AppConfig } from '../app.config';

@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private http: Http,
    public snackBar: MatSnackBar,
    public router: Router
  ) {
   }

  private params;
  private hoteis: Array<any> = [];
  private reservas: Array<any> = [];

  ngOnInit() {
    this.params = this.route.snapshot.queryParams;
    let searchParams = new URLSearchParams();

    searchParams.set('dataInicio', this.params.dataInicio);
    searchParams.set('dataTermino', this.params.dataTermino);
    searchParams.set('enderecoId', this.params.enderecoId);
    searchParams.set('cidade', this.params.cidade);
    searchParams.set('guests', this.params.guests);

    this.http.get(AppConfig.BASE_URL + '/hotel/GetHoteisPorData', {search: searchParams}).
      subscribe((data) => {
        console.log('Resultado: ', data.json());
        this.hoteis = data.json();
    });
  }

  adicionarAcomodacao(hotel) {
    hotel.checked = !hotel.checked;
    if (hotel.checked) {
      this.reservas.push(hotel);
    }else {
      this.reservas.splice(this.reservas.indexOf(hotel), 1);
    }
    console.log('Mudou', hotel.checked, hotel.AcomodacaoId, this.reservas);
  }

  finalizarCompra() {
    console.log('Post acionado!');
    let searchParams = new URLSearchParams();

    let res = new ReservaSimplificadaShared();
    res.AcomodacaoId = this.reservas[0].AcomodacaoId;
    res.Valor = this.reservas[0].Valor;
    res.CodigoLocacao = 'abc123';
    res.DataInicio = this.params.dataInicio;
    res.DataTermino = this.params.dataTermino;

    let arrayRes = new Array<ReservaSimplificadaShared>();
    arrayRes.push(res);

    // searchParams.set('reservas', JSON.stringify(arrayRes));
    // searchParams.set('clienteId', '1');
    // searchParams.set('DataInicio', this.params.dataInicio);
    // searchParams.set('DataTermino', this.params.dataTermino);
    // searchParams.set('guests', this.params.guests);

    let reservas = new CompraFinalizadaSharedViewModel();
    reservas.DataInicio = this.params.dataInicio;
    reservas.DataTermino = this.params.dataTermino;
    reservas.reservas = arrayRes;
    searchParams.set('reservas', JSON.stringify(reservas));

    const _headers = new Headers();
    _headers.append('Content-Type', 'application/json');
    _headers.append('Access-Control-Allow-Methods', 'POST');
    _headers.append('Access-Control-Allow-Origin', '*');
    let options = new RequestOptions({ headers: _headers });

    if (this.reservas) {
      console.log('Reservas enviadas: ', reservas);
      this.http.post(AppConfig.BASE_URL + '/reserva/FinalizarCompra',
      JSON.stringify({reservas: reservas}),
      options).
      subscribe((data) => {
        console.log('Compra realizada com sucesso!');
        this.snackBar.open('Compra realizada com sucesso', 'Fechar', {
          duration: 2000,
        });

        console.log('Carros ofertados');
        this.http.get(AppConfig.BASE_URL + '/hotel/ObterCarros')
        .subscribe(carros => {
          let strJson: string = carros.json();
          console.log(JSON.parse(strJson));
        });

      },
      erro => {
        console.log('Ooops! Algo de errado :(');
      });
    }
  }

}

class CompraFinalizadaSharedViewModel {
  public DataInicio: Date;
  public DataTermino: Date;
  public reservas: Array<ReservaSimplificadaShared>;
}

class ReservaSimplificadaShared {
    public AcomodacaoId: number;
    public Valor: number;
    public CodigoLocacao: string;
    public DataInicio: Date;
    public DataTermino: Date;
}
