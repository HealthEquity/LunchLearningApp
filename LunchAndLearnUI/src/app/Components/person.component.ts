import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Person } from '../Models/person';
import { PersonService } from '../Services/person.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'my-persons',
  templateUrl: '../Views/person.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class PersonComponent implements OnInit {
 persons: Person[] = [];
 newPerson: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private personService: PersonService) {
  }

  ngOnInit(): void {
       this.personService.getPersons().pipe(first())
            .subscribe(
            value => this.persons = value
            );

       this.newPerson = this.formBuilder.group({
            name: ['', [Validators.required]],
            isActive: ['']
        });    
    }

    createPerson({ value, valid }: {value: Person, valid: boolean}) {
      this.personService.create(value).pipe(first())
      .subscribe(() => {
        this.loadAllPersons();  
      });
      this.newPerson.reset();
    }

    loadAllPersons() {
        this.personService.getPersons().pipe(first()).subscribe(persons => { 
            this.persons = persons; 
        });
    }

}