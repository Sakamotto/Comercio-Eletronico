import { Injectable } from '@angular/core';
import { CrudService } from '../shared/crud.service';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Cliente } from './models';

@Injectable()
export class LoginService extends CrudService {

  constructor(http: Http) {
    super(http, 'cliente');
  }

  logado(): boolean {
    return localStorage.getItem("email") !== null;
  }

  login(email: string, senha: string): Observable<any> {
    const credenciais = {Email: email, Senha: senha};
    return this.postAny('AutenticarUsuario', credenciais)
    .map(data => {
        if(data.sucesso){
          localStorage.setItem("email", email);
          localStorage.setItem("id", data.retorno.Id);
        }
        return data;
    });
  }

  cadastrar(cliente: Cliente): Observable<any> {
    return this.post(cliente);
  }

  logout() {
    localStorage.removeItem("email");
    localStorage.removeItem("id");
  }

}
