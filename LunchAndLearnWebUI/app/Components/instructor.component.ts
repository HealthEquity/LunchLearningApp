import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Instructor } from '../Models/instructor';
import { InstructorService } from '../Services/instructor.service';

@Component({
  moduleId: module.id,
  selector: 'my-instructors',
  templateUrl: '../Views/instructor.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class InstructorComponent implements OnInit {
 instructors: Instructor[] = [];
 newInstructor: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private instructorService: InstructorService) {
  }

  ngOnInit(): void {
       this.instructorService.getInstructors()
            .subscribe(
            value => this.instructors = value
            );

       this.newInstructor = this.formBuilder.group({
            instructorName: ['', [Validators.required]],
            isActive: ['']
        });    
  }

    createInstructor({ value, valid }: {value: Instructor, valid: boolean}) {
      this.instructorService.create(value)
      .subscribe(
      value => this.instructors.push(value));
      this.newInstructor.reset();
  }

}