import { Component, OnInit, ViewChild, AfterViewInit, ViewContainerRef } from '@angular/core';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Location } from '@angular/common';
import { Http } from '@angular/http';
import { ReservaService } from './reserva.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AppConfig } from '../app.config';
import { AcomodacaoService } from '../acomodacao/acomodacao.service';
import { HotelComponent } from '../hotel/hotel.component';
import { UtilService } from '../shared/util.service';
import { LoginService } from '../login/login.service';
import { Cliente } from '../login/models';
import { Reserva } from './models';

declare var $: any;

@Component({
  selector: 'reserva-confirmar',
  templateUrl: './reserva-confirmar.component.html',
  styleUrls: ['./reserva.component.css'],
  providers: [ReservaService, AcomodacaoService, UtilService, LoginService]
})
export class ReservaConfirmarComponent implements OnInit, AfterViewInit {

  constructor(
    private http: Http,
    private router: Router,
    private route: ActivatedRoute,
    private reservaService: ReservaService,
    private location: Location,
    private acomodacaoService: AcomodacaoService,
    private utilService: UtilService,
    private loginService: LoginService,
    public toastr: ToastsManager,
    vcr: ViewContainerRef
  ) { 
    // this.toastr.setRootViewContainerRef(vcr);
  }

    private reservaId: number;
    public acomodacao: any;
    public params: any;
    public detalhesAcomodcao: any;
    public showSpinner = true;
    public logado = false;
    public cliente: Cliente = new Cliente();
    public sucesso = false;
    public erroLogin = false;
    private totalReserva;

  ngOnInit() {
    let acomodacaoId = this.route.snapshot.queryParams['id'];
    this.params = this.route.snapshot.queryParams;
    
    this.acomodacaoService.get(acomodacaoId)
      .subscribe(data => {
        this.acomodacao = data;
        this.showSpinner = false
      }, error => this.showSpinner = false);
      this.logado = this.loginService.logado();
  }
  
  getTotal(valor: number){
    if(valor){
      let inicio = new Date(this.params.dataInicio);
      let termino = new Date(this.params.dataTermino);
      let qtdDias = termino.getDate() - inicio.getDate();
      this.totalReserva = qtdDias * valor;
      return qtdDias * valor;
    }
  }

  ngAfterViewInit(){}

  public voltar(): void{
    this.location.back();
  }

  login(){
    this.loginService.login(this.cliente.Email, this.cliente.Senha)
    .subscribe(data => {
      if(data.sucesso){
        this.toastr.success("Usuário logado com sucesso!!", "Sucesso!");
        this.sucesso = true;
        this.logado = true;
        this.erroLogin = false;
      }else{
        this.erroLogin = true;
      }
    });
  }

  registrar() {
    this.showSpinner = true;
    this.cliente.DataNascimento = new Date(1980, 7, 30);
    this.loginService.cadastrar(this.cliente)
    .subscribe(
      data => {
        this.showSpinner = false;
    });
  }

  confirmarReserva(){
    let reserva = new Reserva();
    reserva.AcomodacaoId = this.acomodacao.Id;
    reserva.ClienteId = +localStorage.getItem("id");
    reserva.CodigoLocacao = '';
    reserva.DataInicio = this.params.dataInicio;
    reserva.DataTermino = this.params.dataTermino;
    reserva.Valor = this.totalReserva;

    // this.reservaService.obterCarrosDisponiveis(this.params.dataInicio, this.params.dataTermino)
    // .subscribe(data => {
    //     console.log("Retorno: ", data);
    // });

    this.reservaService.finalizarReserva(reserva)
    .subscribe(data => {
      if(data.sucesso){
        this.toastr.success("Reserva finalizada com sucesso!", "Sucesso!");

        // redireciona para a página que oferta os carros
        this.redirect(data.retorno.Id);
      }else {
        this.toastr.error("Ocorreu um erro ao realizar a reserva, tente novamente.", "Erro!");
      }
      console.log("Retorno: ", data);
    });

  }

  redirect(reservaId: number){
    let parametros: any;
    
    parametros = {
      id: reservaId, // < -- Acho que precisa passar o ID da reserva que o cliente realizou
      dataInicio: this.params.dataInicio,
      dataTermino: this.params.dataTermino,
      cidade: this.params.cidade,
      guests: this.params.guests
    }
    this.router.navigate(['/oferta-carros'], {queryParams: parametros});
  }

}
