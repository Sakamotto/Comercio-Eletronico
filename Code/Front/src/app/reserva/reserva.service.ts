import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { CrudService } from '../shared/crud.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ReservaService extends CrudService {

    constructor(http: Http) {
        super(http, 'reserva');
    }

    public finalizarReserva(dados?: any): Observable<any> {
        return this.postAny('FinalizarCompra', dados);
    }

    public obterCarrosDisponiveis(dataInicio: Date, dataTermino: Date): Observable<any>{
        return this.getAny('ObterCarrosDisponiveis', {dataInicio: dataInicio, dataTermino: dataTermino});
    }

}
