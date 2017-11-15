import { Injectable } from '@angular/core';
import { Http, RequestOptions, RequestOptionsArgs, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AppConfig } from '../app.config';

@Injectable()
export class CrudService {
    // tslint:disable-next-line:no-trailing-whitespace
    private endpoint: string;

    constructor(
        protected http: Http,
        protected uri: string
    ) {
        this.endpoint = AppConfig.BASE_URL + '/' + uri;
    }

    public getAll(): Observable<any> {
        console.log('Endpoint: ', this.endpoint);
        return this.http.get(this.endpoint)
        .map(t => t.json());
    }

    public get(id: number): Observable<any> {
        return this.http.get(this.endpoint + '/' + id).map(data => data.json());
    }

    public getOne(end: string, id: number): Observable<any> {
        return this.http.get(this.endpoint + '/'+ end + '/' + id).map(data => data.json());
    }

    public post(obj: any): Observable<any> {
        return this.http.post(this.endpoint, obj);
    }

    public delete(id: number): Observable<any> {
        return this.http.delete(this.endpoint + '/' + id);
    }

    // rever
    put(obj: any): Observable<any> {
        return this.http.put(this.endpoint, obj);
    }

    public postAny(end: string, dados?: any): Observable<any> {
        const body = JSON.stringify(dados);
        let _headers = new Headers();
        _headers.append('Content-Type', 'application/json');
        _headers.append('Access-Control-Allow-Methods', 'POST');
        let opt = new RequestOptions({headers: _headers});
        return this.http.post(this.endpoint + '/' + end, body, {headers: _headers})
            .map(data => data.json());
    }

    public getAny(end: string, dados?: any): Observable<any> {
        return this.http.get(this.endpoint + '/' + end, {search: dados})
            .map(data => data.json());
    }

    // protected extractData(res: Response): Object {
    //  // Verifica se a resposta do servidor contém JSON.
    //  const hasJson = /json/.test(res.headers.get('Content-Type'));
    //     let body: any;
    //     if (hasJson) {
    //         return res.json();
    //     }else {
    //         return {};
    //     }

    // }

}
