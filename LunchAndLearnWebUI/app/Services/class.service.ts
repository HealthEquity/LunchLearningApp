import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';

import { DbClass } from '../Models/dbClass';

@Injectable()
export class ClassService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private classUrl = 'api/class';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.classUrl = _configuration.ServerWithApiUrl + 'class/';
   }

  getClasses(): Promise<DbClass[]> {
    return this.http.get(this.classUrl + '/all')
               .toPromise()
               .then(response => response.json().data as DbClass[])
               .catch(this.handleError);
  }


  getClass(id: number): Promise<DbClass> {
    const url = `${this.classUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as DbClass)
      .catch(this.handleError);
  }

  delete(id: number): Promise<void> {
    const url = `${this.classUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  create(name: string): Promise<DbClass> {
    return this.http
      .post(this.classUrl, JSON.stringify({name: name}), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

  update(dbClass: DbClass): Promise<DbClass> {
    const url = `${this.classUrl}/${dbClass.id}`;
    return this.http
      .put(url, JSON.stringify(dbClass), {headers: this.headers})
      .toPromise()
      .then(() => dbClass)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}