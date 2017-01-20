import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Track } from '../Models/track';

@Injectable()
export class TrackService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private trackUrl = 'api/track';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.trackUrl = _configuration.ServerWithApiUrl + 'track/';
   }
  
  getTracks() {
        return this.http.get(this.trackUrl + 'all')
            .map(res => <Track[]>res.json())
            .catch(this.handleError);
    }

    getTrack(id: number) {
        const url = `${this.trackUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Track>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.trackUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(track: Track) {
    return this.http
      .post(this.trackUrl, JSON.stringify(track), {headers: this.headers})
      .map(res => res.json().data)
      .catch(this.handleError);
  }
  
  update(track: Track) {
    const url = `${this.trackUrl}/${track.id}`;
    return this.http
      .put(url, JSON.stringify(track), {headers: this.headers})
      .map(() => track)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}