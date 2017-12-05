import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomMaterialModule } from './custom-material.module';


import { AppComponent } from './app.component';
import { AppRoutingModule, routingComponents } from './app.routing.module';

import { TrackDetailsComponent } from './track-details/track-details.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { RoomDetailsComponent } from './room-details/room-details.component';
import { SessionDetailsComponent } from './session-details/session-details.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { CoursesComponent } from './courses/courses.component';
import { SessionsComponent } from './sessions/sessions.component';
import { TracksComponent } from './tracks/tracks.component';
import { RoomsComponent } from './rooms/rooms.component';
import { PersonsComponent } from './persons/persons.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NavigationComponent } from './navigation/navigation.component';
import { PersonSignupComponent } from './person-signup/person-signup.component';
import { PersonLoginComponent } from './person-login/person-login.component';




@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    TrackDetailsComponent,
    CourseDetailsComponent,
    RoomDetailsComponent,
    SessionDetailsComponent,
    PersonDetailsComponent,
    CoursesComponent,
    SessionsComponent,
    TracksComponent,
    RoomsComponent,
    PersonsComponent,
    PageNotFoundComponent,
    NavigationComponent,
    PersonSignupComponent,
    PersonLoginComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    AppRoutingModule
  ],
  entryComponents: [
    PersonLoginComponent,
    PersonSignupComponent,
    CourseDetailsComponent
  ],
  exports: [CustomMaterialModule],
  providers: [CustomMaterialModule],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
