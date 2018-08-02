import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { Rating } from '../Models/rating';

@Injectable({ providedIn: 'root'})
export class RatingService {

  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private ratingUrl = 'api/rating';  // URL to web api

  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.ratingUrl = _configuration.ServerWithApiUrl + 'rating/';
   }
  
  getRatings() {
        return this.http.get<Rating[]>(this.ratingUrl + 'all');
    }

    getRating(id: number) {
        const url = `${this.ratingUrl}/${id}`;
        return this.http.get<Rating>(url);
    }

  delete(id: number) {
    const url = `${this.ratingUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(rating: Rating) {
    return this.http
      .post(this.ratingUrl + 'create', JSON.stringify(rating), {headers: this.headers});
  }
  
  update(rating: Rating) {
    const url = `${this.ratingUrl}/${rating.id}`;
    return this.http
      .put(url, JSON.stringify(rating), {headers: this.headers});
  }
}