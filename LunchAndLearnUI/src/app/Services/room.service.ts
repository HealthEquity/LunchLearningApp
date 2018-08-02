import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { Room } from '../Models/room';

@Injectable({ providedIn: 'root'})
export class RoomService {
  private roomUrl = 'api/room';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.roomUrl = _configuration.ServerWithApiUrl + 'room/';
   }
  
  getRooms() {
        return this.http.get<Room[]>(this.roomUrl + 'all');
    }

    getRoom(id: number) {
        const url = `${this.roomUrl}/${id}`;
        return this.http.get<Room>(url);
    }

  delete(id: number) {
    const url = `${this.roomUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(room: Room) {
    return this.http
      .post(this.roomUrl + 'create', JSON.stringify(room), {headers: this.headers});
  }
  
  update(room: Room) {
    const url = `${this.roomUrl}/${room.id}`;
    return this.http
      .put(url, JSON.stringify(room), {headers: this.headers});
  }
}