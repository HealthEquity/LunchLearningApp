import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DbCourse } from '../Models/dbCourse';
import { CourseService } from '../Services/course.service';

@Component({
  moduleId: module.id,
  selector: 'my-dashboard',
  templateUrl: '../Views/dashboard.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class DashboardComponent implements OnInit {
  courses: DbCourse[] = [];

  constructor(
    private router: Router,
    private courseService: CourseService) {
  }

  ngOnInit(): void {
       this.courseService.getCourses()
            .subscribe(
            value => this.courses = value.slice(1, 5)
            );
  }

}