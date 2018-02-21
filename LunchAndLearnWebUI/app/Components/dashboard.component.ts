import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Course } from '../Models/course';
import { CourseService } from '../Services/course.service';

@Component({
  moduleId: module.id,
  selector: 'my-dashboard',
  templateUrl: '../Views/dashboard.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class DashboardComponent implements OnInit {
  courses: Course[] = [];

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