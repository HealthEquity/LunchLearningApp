import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { SessionAttendee } from '../Models/sessionAttendee';

@Injectable()
export class SessionAttendeeService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private sessionAttendeeUrl = 'api/sessionattendee';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.sessionAttendeeUrl = _configuration.ServerWithApiUrl + 'sessionAttendee/';
   }
  
  enroll(sessionAttendee: SessionAttendee) {
    return this.http
    .post(this.sessionAttendeeUrl + 'create', JSON.stringify(sessionAttendee), {headers: this.headers})
    .map((res: Response) => res.json())
    .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}