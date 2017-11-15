import { Injectable } from "@angular/core";
import { Subject } from "rxjs/Subject";


@Injectable()
export class UtilService {
    public data = new Subject<any>();

    addBasicData(dados){
        this.data.next(dados);
    }

}