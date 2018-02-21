import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Course } from '../Models/course';
import { CourseService } from '../Services/course.service';

@Component({
  moduleId: module.id,
  selector: 'my-classes',
  templateUrl: '../Views/courses.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class CoursesComponent implements OnInit {
  courses: Course[] = [];
  newCourse: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private courseService: CourseService) {
  }

  ngOnInit(): void {
       this.courseService.getCourses()
            .subscribe(
            value => this.courses = value
            );

      this.newCourse = this.formBuilder.group({
            courseName: ['', [Validators.required, Validators.minLength(2)]],
            courseDescription: ['']
        })
        
  }

  createClass({ value, valid }: {value: Course, valid: boolean}) {
      this.courseService.create(value)
      .subscribe(
      value => this.courses.push(value));
      this.newCourse.reset();
  }

}