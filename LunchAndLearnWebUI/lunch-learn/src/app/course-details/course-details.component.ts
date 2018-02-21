import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Course } from './course'

@Component({
  selector: 'll-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  courseForm: FormGroup;
  course: Course = new Course();

  constructor(private fb: FormBuilder) { }
  
    ngOnInit() {
      this.courseForm = this.fb.group({
        courseId: null,
        courseName: ['', [Validators.required]],
        courseDescription: ['', Validators.required]
      });
    }

    save() {
      console.log(this.courseForm);
      console.log('Saved: ' + JSON.stringify(this.courseForm.value));
    }
  
}
