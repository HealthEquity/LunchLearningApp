import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';


import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { CourseDetailsComponent} from '../course/course-details/course-details.component';
import { CourseListComponent} from '../course/course-list/course-list.component';


@NgModule({
    declarations: [
        CourseDetailsComponent,
        CourseListComponent
    ],
    imports: [
      BrowserModule,
      ReactiveFormsModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [CourseDetailsComponent, CourseListComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class CourseModule { }