import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ReservaService } from './reserva.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HotelService } from '../hotel/hotel.service';
import { AppConfig } from '../app.config';
import { AcomodacaoService } from '../acomodacao/acomodacao.service';

@Component({
  selector: 'app-reserva',
  templateUrl: './reserva.component.html',
  styleUrls: ['./reserva.component.css'],
  providers: [ReservaService, AcomodacaoService]
})
export class ReservaComponent implements OnInit {

  constructor(
    private http: Http,
    private router: Router,
    private route: ActivatedRoute,
    private reservaService: ReservaService,
    private location: Location,
    private acomodacaoService: AcomodacaoService) { }

    public acomodacao: any;
    public params: any;
    public showSpinner = true;

  ngOnInit() {
    let id = this.route.snapshot.queryParams['id'];
    this.params = this.route.snapshot.queryParams;
    
    this.acomodacaoService.get(id)
      .subscribe(data => {
        this.acomodacao = data;
        this.showSpinner = false;
      }, error => this.showSpinner = false);
  }

  redirect(){
    //[routerLink]="['/confirmar-reserva/', acomodacao?.Id]"
    this.router.navigate(['/confirmar-reserva'], {queryParams: this.params});
  }

  public voltar(): void{
    this.location.back();
  }

}
