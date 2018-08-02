import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { TrackSession } from '../Models/trackSession';

@Injectable({ providedIn: 'root'})
export class TrackSessionService {

  private trackSessionUrl = 'api/trackSession';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.trackSessionUrl = _configuration.ServerWithApiUrl + 'trackSession/';
   }
  
  getTrackSessions() {
        return this.http.get<TrackSession[]>(this.trackSessionUrl + 'all');
    }

    getTrackSession(id: number) {
        const url = `${this.trackSessionUrl}/${id}`;
        return this.http.get<TrackSession>(url)
    }

    getUpcomingTrackSessions() {
      return this.http.get<TrackSession[]>(this.trackSessionUrl + 'upcoming');
   }

   getMyTrackSessions(personId) {
    return this.http.get<TrackSession[]>(this.trackSessionUrl + 'mysessions?' + personId);
   }

  delete(id: number) {
    const url = `${this.trackSessionUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(trackSession: TrackSession) {
    return this.http
      .post(this.trackSessionUrl + 'create', JSON.stringify(trackSession), {headers: this.headers});
  }
  
  update(trackSession: TrackSession) {
    return this.http
      .put(this.trackSessionUrl + 'update', JSON.stringify(trackSession), {headers: this.headers});
  }

  enroll(trackSession: TrackSession) {
    return this.http
    .post(this.trackSessionUrl + 'enroll', JSON.stringify(trackSession), {headers: this.headers});
  }
}