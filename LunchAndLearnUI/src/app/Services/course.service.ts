import { Injectable }    from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { Course } from '../Models/course';

@Injectable( { providedIn: 'root'})
export class CourseService {

  private courseUrl = 'api/course';  // URL to web api
  private headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': 'Allow'});
  constructor(private http: HttpClient, private _configuration: Configuration) {
    this.courseUrl = _configuration.ServerWithApiUrl + 'course/';
   }
  
  getCourses() {
        return this.http.get<Course[]>(this.courseUrl + 'all');
    }

  getCourse(id: number) {
      const url = `${this.courseUrl}/${id}`;
      return this.http.get<Course>(url);
  }

  delete(id: number) {
    const url = `${this.courseUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers});
  }

   create(course: Course) {
    return this.http
      .post(this.courseUrl + 'create', JSON.stringify(course), {headers: this.headers});
  }
  
  update(course: Course) {
    const url = `${this.courseUrl}/${course.id}`;
    return this.http
      .put(url, JSON.stringify(course), {headers: this.headers});
  }
}