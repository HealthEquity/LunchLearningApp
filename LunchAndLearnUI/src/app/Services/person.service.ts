import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { Person } from '../Models/person';

@Injectable({ providedIn: 'root'})
export class PersonService {

  private personUrl = 'api/person';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.personUrl = _configuration.ServerWithApiUrl + 'person/';
   }
  
  getPersons() {
        return this.http.get<Person[]>(this.personUrl + 'all');
    }

    getPerson(id: number) {
      const url = `${this.personUrl}/${id}`;
      return this.http.get<Person>(url);
    }

  delete(id: number) {
    const url = `${this.personUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(person: Person) {
    return this.http
      .post(this.personUrl + 'create', JSON.stringify(person), {headers: this.headers});
  }
  
  update(person: Person) {
    const url = `${this.personUrl}/${person.id}`;
    return this.http
      .put(url, JSON.stringify(person), {headers: this.headers});
  }

}