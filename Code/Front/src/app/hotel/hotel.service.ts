import { Injectable } from '@angular/core';
import { CrudService } from '../shared/crud.service';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HotelService extends CrudService {

    constructor(http: Http) {
        super(http, 'hotel');
    }

    // Aqui vem os métodos específicos de cada classe

    public carrosDisponiveis(dados: any): Observable<any>{
        return this.getAny('ObterCarrosDisponiveis', dados);
    }

    public getAcomodacao(id: number): Observable<any> {
        return this.getOne('GetAcomodacao', id);
    }
}
