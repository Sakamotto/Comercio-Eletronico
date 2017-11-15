import { Injectable } from '@angular/core';
import { CrudService } from '../shared/crud.service';
import { Http } from '@angular/http';

@Injectable()
export class AcomodacaoService extends CrudService {

    constructor(http: Http) {
        super(http, 'acomodacao');
    }

    public getAcomodacao(id: number){
        return this.getAny('GetAcomodacao', id);
    }
}