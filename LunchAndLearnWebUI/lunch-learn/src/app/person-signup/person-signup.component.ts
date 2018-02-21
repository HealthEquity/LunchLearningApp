import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'll-person-signup',
  templateUrl: './person-signup.component.html',
  styleUrls: ['./person-signup.component.css']
})
export class PersonSignupComponent implements OnInit {
  personSignUpForm: FormGroup
  
    constructor(private fb: FormBuilder) { }
    
      ngOnInit() {
        this.personSignUpForm = this.fb.group({
          personId: null,
          personName: ['', [Validators.required]],
          personEmail: '',
          personUserName: '',
          personPassword: ['', Validators.required]
        });
      }
  
      save() {
        console.log(this.personSignUpForm);
        console.log('Saved: ' + JSON.stringify(this.personSignUpForm.value));
      }
  
  }
