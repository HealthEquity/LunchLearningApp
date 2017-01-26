import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Room } from '../Models/room';

@Injectable()
export class RoomService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private roomUrl = 'api/room';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.roomUrl = _configuration.ServerWithApiUrl + 'room/';
   }
  
  getRooms() {
        return this.http.get(this.roomUrl + 'all')
            .map(res => <Room[]>res.json())
            .catch(this.handleError);
    }

    getRoom(id: number) {
        const url = `${this.roomUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Room>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.roomUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(room: Room) {
    return this.http
      .post(this.roomUrl + 'create', JSON.stringify(room), {headers: this.headers})
      .map((res: Response) => res.json())
      .catch(this.handleError);
  }
  
  update(room: Room) {
    const url = `${this.roomUrl}/${room.id}`;
    return this.http
      .put(url, JSON.stringify(room), {headers: this.headers})
      .map(() => room)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}