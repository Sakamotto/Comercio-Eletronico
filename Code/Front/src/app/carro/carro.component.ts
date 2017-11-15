import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservaService } from '../reserva/reserva.service';

@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html',
  styleUrls: ['./carro.component.css'],
  providers: [ReservaService]
})
export class CarroComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private reservaService: ReservaService
  ) { }

  public params: any;
  public carros: any;
  public showSpinner = true;

  ngOnInit() {
    this.params = this.route.snapshot.queryParams;

    this.reservaService.obterCarrosDisponiveis(this.params.dataInicio, this.params.dataTermino)
    .subscribe(data => {
      this.carros = data.Dados;
      this.showSpinner = false;
      console.log("Retorno: ", this.carros);
    });

  }

}
