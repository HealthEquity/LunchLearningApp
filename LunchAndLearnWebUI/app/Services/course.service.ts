import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import { Course } from '../Models/course';

@Injectable()
export class CourseService {

  private headers = new Headers({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  private courseUrl = 'api/course';  // URL to web api

  constructor(private http: Http, private _configuration: Configuration) {
    this.courseUrl = _configuration.ServerWithApiUrl + 'course/';
   }
  
  getCourses() {
        return this.http.get(this.courseUrl + 'all')
            .map(res => <Course[]>res.json())
            .catch(this.handleError);
    }

  getCourse(id: number) {
      const url = `${this.courseUrl}/${id}`;
      return this.http.get(url)
          .map(res => <Course>res.json())
          .catch(this.handleError);
  }

  delete(id: number) {
    const url = `${this.courseUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
    .map(() => null)
    .catch(this.handleError);
  }

   create(course: Course) {
    return this.http
      .post(this.courseUrl + 'create', JSON.stringify(course), {headers: this.headers})
      .map((res: Response) => res.json())
      .catch(this.handleError);
  }
  
  update(course: Course) {
    const url = `${this.courseUrl}/${course.id}`;
    return this.http
      .put(url, JSON.stringify(course), {headers: this.headers})
      .map(() => course)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}