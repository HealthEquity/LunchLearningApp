import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Person } from '../Models/person';

@Injectable()
export class PersonService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private personUrl = 'api/person';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.personUrl = _configuration.ServerWithApiUrl + 'person/';
   }
  
  getPersons() {
        return this.http.get(this.personUrl + 'all')
            .map(res => <Person[]>res.json())
            .catch(this.handleError);
    }

    getPerson(id: number) {
        const url = `${this.personUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Person>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.personUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(person: Person) {
    return this.http
      .post(this.personUrl + 'create', JSON.stringify(person), {headers: this.headers})
      .map((res: Response) => res.json())
      .catch(this.handleError);
  }
  
  update(person: Person) {
    const url = `${this.personUrl}/${person.id}`;
    return this.http
      .put(url, JSON.stringify(person), {headers: this.headers})
      .map(() => person)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}