import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'll-person-login',
  templateUrl: './person-login.component.html',
  styleUrls: ['./person-login.component.css']
})
export class PersonLoginComponent implements OnInit {
  personLoginForm: FormGroup

  constructor(private fb: FormBuilder) { }
  
    ngOnInit() {
      this.personLoginForm = this.fb.group({
        personId: null,
        personUserName: ['', [Validators.required]],
        personPassword: ['', Validators.required]
      });
    }

    save() {
      console.log(this.personLoginForm);
      console.log('Saved: ' + JSON.stringify(this.personLoginForm.value));
    }

}
