import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Rating } from '../Models/rating';

@Injectable()
export class RatingService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private ratingUrl = 'api/rating';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.ratingUrl = _configuration.ServerWithApiUrl + 'rating/';
   }
  
  getRatings() {
        return this.http.get(this.ratingUrl + 'all')
            .map(res => <Rating[]>res.json())
            .catch(this.handleError);
    }

    getRating(id: number) {
        const url = `${this.ratingUrl}/${id}`;
        return this.http.get(url)
            .map(res => <Rating>res.json())
            .catch(this.handleError);
    }

  delete(id: number) {
    const url = `${this.ratingUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(rating: Rating) {
    return this.http
      .post(this.ratingUrl + 'create', JSON.stringify(rating), {headers: this.headers})
      .map((res : Response) => res.json())
      .catch(this.handleError);
  }
  
  update(rating: Rating) {
    const url = `${this.ratingUrl}/${rating.id}`;
    return this.http
      .put(url, JSON.stringify(rating), {headers: this.headers})
      .map(() => rating)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}