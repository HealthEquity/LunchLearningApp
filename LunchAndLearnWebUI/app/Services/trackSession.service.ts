import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { TrackSession } from '../Models/trackSession';

@Injectable()
export class TrackSessionService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private trackSessionUrl = 'api/trackSession';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.trackSessionUrl = _configuration.ServerWithApiUrl + 'trackSession/';
   }
  
  getTrackSessions() {
        return this.http.get(this.trackSessionUrl + 'all')
            .map(res => <TrackSession[]>res.json())
            .catch(this.handleError);
    }

    getTrackSession(id: number) {
        const url = `${this.trackSessionUrl}/${id}`;
        return this.http.get(url)
            .map(res => <TrackSession>res.json())
            .catch(this.handleError);
    }

    getUpcomingTrackSessions() {
      return this.http.get(this.trackSessionUrl + 'upcoming')
      .map(res => <TrackSession[]>res.json())
      .catch(this.handleError);
   }

   getMyTrackSessions(personId) {
    return this.http.get(this.trackSessionUrl + 'mysessions?' + personId)
    .map(res => <TrackSession[]>res.json())
    .catch(this.handleError);
   }

  delete(id: number) {
    const url = `${this.trackSessionUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(trackSession: TrackSession) {
    return this.http
      .post(this.trackSessionUrl + 'create', JSON.stringify(trackSession), {headers: this.headers})
      .map((res: Response) => res.json())
      .catch(this.handleError);
  }
  
  update(trackSession: TrackSession) {
    return this.http
      .put(this.trackSessionUrl + 'update', JSON.stringify(trackSession), {headers: this.headers})
      .map(() => trackSession)
      .catch(this.handleError);
  }

  enroll(trackSession: TrackSession) {
    return this.http
    .post(this.trackSessionUrl + 'enroll', JSON.stringify(trackSession), {headers: this.headers})
    .map((res: Response) => res.json())
    .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}