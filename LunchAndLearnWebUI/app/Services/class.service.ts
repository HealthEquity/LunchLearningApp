import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { DbClass } from '../Models/dbClass';

@Injectable()
export class ClassService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private classUrl = 'api/class';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.classUrl = _configuration.ServerWithApiUrl + 'class/';
   }
  
  getClasses() {
        return this.http.get(this.classUrl + 'all')
            .map(res => <DbClass[]>res.json())
            .catch(this.handleError);
    }

  getClass(id: number) {
      const url = `${this.classUrl}/${id}`;
      return this.http.get(url)
          .map(res => <DbClass>res.json())
          .catch(this.handleError);
  }

  delete(id: number) {
    const url = `${this.classUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(dbClass: DbClass) {
    return this.http
      .post(this.classUrl + 'create', JSON.stringify(dbClass), {headers: this.headers})
      .map((res: Response) => res.json())
      .catch(this.handleError);
  }
  
  update(dbClass: DbClass) {
    const url = `${this.classUrl}/${dbClass.id}`;
    return this.http
      .put(url, JSON.stringify(dbClass), {headers: this.headers})
      .map(() => dbClass)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}