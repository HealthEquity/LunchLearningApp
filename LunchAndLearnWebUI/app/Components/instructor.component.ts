import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(
    private router: Router,
    private InstructorService: InstructorService) {
  }

  ngOnInit(): void {
       this.InstructorService.getInstructors()
            .subscribe(
            value => this.instructors = value
            );
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}