import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { DbClass } from '../Models/dbClass';
import { ClassService } from '../Services/class.service';

@Component({
  moduleId: module.id,
  selector: 'my-classes',
  templateUrl: '../Views/classes.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class ClassesComponent implements OnInit {
  classes: DbClass[] = [];
  newClass: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private classService: ClassService) {
  }

  ngOnInit(): void {
       this.classService.getClasses()
            .subscribe(
            value => this.classes = value
            );

      this.newClass = this.formBuilder.group({
            className: ['', [Validators.required, Validators.minLength(2)]],
            classDescription: ['']
        })
        
  }

  createClass({ value, valid }: {value: DbClass, valid: boolean}) {
      this.classService.create(value)
      .subscribe(
      value => this.classes.push(value));
      this.newClass.reset();
  }


//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}