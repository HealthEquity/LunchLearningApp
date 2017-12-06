import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { PersonDetailsComponent } from '../person/person-details/person-details.component';
import { PersonListComponent } from '../person/person-list/person-list.component';
import { PersonLoginComponent } from '../person/person-login/person-login.component';
import { PersonSignupComponent } from '../person/person-signup/person-signup.component';


@NgModule({
    declarations: [
        PersonDetailsComponent,
        PersonLoginComponent,
        PersonSignupComponent,
        PersonListComponent
    ],
    imports: [
      BrowserModule,
      ReactiveFormsModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [PersonDetailsComponent, PersonListComponent, PersonLoginComponent, PersonSignupComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class PersonModule { }
  