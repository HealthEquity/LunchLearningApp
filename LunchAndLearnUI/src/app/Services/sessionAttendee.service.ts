import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { SessionAttendee } from '../Models/sessionAttendee';

@Injectable({ providedIn: 'root'})
export class SessionAttendeeService {

  private sessionAttendeeUrl = 'api/sessionattendee';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.sessionAttendeeUrl = _configuration.ServerWithApiUrl + 'sessionAttendee/';
   }
  
  enroll(sessionAttendee: SessionAttendee) {
    return this.http
    .post(this.sessionAttendeeUrl + 'create', JSON.stringify(sessionAttendee), {headers: this.headers});
  }

  unenroll(id: number) {
    const url = `${this.sessionAttendeeUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

}