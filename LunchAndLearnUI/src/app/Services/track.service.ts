import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { Track } from '../Models/track';

@Injectable({ providedIn: 'root'})
export class TrackService {

  private trackUrl = 'api/track';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.trackUrl = _configuration.ServerWithApiUrl + 'track/';
   }
  
  getTracks() {
        return this.http.get<Track[]>(this.trackUrl + 'all');
    }

    getTrack(id: number) {
        const url = `${this.trackUrl}/${id}`;
        return this.http.get<Track>(url);
    }

  delete(id: number) {
    const url = `${this.trackUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(track: Track) {
    return this.http
      .post(this.trackUrl + 'create', JSON.stringify(track), {headers: this.headers});
  }
  
  update(track: Track) {
    const url = `${this.trackUrl}/${track.id}`;
    return this.http
      .put(url, JSON.stringify(track), {headers: this.headers});
  }
}