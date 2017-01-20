import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Schedule } from '../Models/schedule';

@Injectable()
export class ScheduleService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private scheduleUrl = 'api/schedule';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.scheduleUrl = _configuration.ServerWithApiUrl + 'schedule/';
   }
  
  getSchedules() {
        return this.http.get(this.scheduleUrl + 'all')
            .map(res => <Schedule[]>res.json())
            .catch(this.handleError);
    }

    getSchedule(id: number) {
        const url = `${this.scheduleUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Schedule>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.scheduleUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(schedule: Schedule) {
    return this.http
      .post(this.scheduleUrl, JSON.stringify(schedule), {headers: this.headers})
      .map(res => res.json().data)
      .catch(this.handleError);
  }
  
  update(schedule: Schedule) {
    const url = `${this.scheduleUrl}/${schedule.id}`;
    return this.http
      .put(url, JSON.stringify(schedule), {headers: this.headers})
      .map(() => schedule)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}