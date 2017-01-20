import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Instructor } from '../Models/instructor';

@Injectable()
export class InstructorService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private instructorUrl = 'api/instructor';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.instructorUrl = _configuration.ServerWithApiUrl + 'instructor/';
   }
  
  getInstructors() {
        return this.http.get(this.instructorUrl + 'all')
            .map(res => <Instructor[]>res.json())
            .catch(this.handleError);
    }

    getInstructor(id: number) {
        const url = `${this.instructorUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Instructor>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.instructorUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(instructor: Instructor) {
    return this.http
      .post(this.instructorUrl, JSON.stringify(instructor), {headers: this.headers})
      .map(res => res.json().data)
      .catch(this.handleError);
  }
  
  update(instructor: Instructor) {
    const url = `${this.instructorUrl}/${instructor.id}`;
    return this.http
      .put(url, JSON.stringify(instructor), {headers: this.headers})
      .map(() => instructor)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}