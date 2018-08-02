import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';

import {NgxPaginationModule} from 'ngx-pagination';

import { routing } from '../app/app.routing';
 
import { ErrorInterceptor } from '../app/Helpers/error.interceptor';
import { JwtInterceptor } from '../app/Helpers/jwt.interceptor';

import { LoginComponent } from './Components/login.component';
import { DashboardComponent } from './Components/dashboard.component';

import { CoursesComponent} from './Components/courses.component';
import { PersonComponent} from './Components/person.component';
import { RoomComponent} from './Components/room.component';
import { RatingComponent} from './Components/rating.component';
import { TrackSessionComponent} from './Components/trackSession.component';
import { TrackComponent} from './Components/track.component';

import { CourseService }          from './Services/course.service';
import { PersonService }          from './Services/person.service';
import { RoomService }          from './Services/room.service';
import { RatingService }          from './Services/rating.service';
import { TrackSessionService }          from './Services/trackSession.service';
import { SessionAttendeeService } from './Services/sessionAttendee.service';
import { TrackService }          from './Services/track.service';
import { AuthenticationService } from './Services/authentication.service';

import { AuthGuard } from './Guards/auth.guard';

import { Configuration } from '../app/app.constants';

@NgModule({
  imports: [
      BrowserModule,
      ReactiveFormsModule,
      HttpClientModule,
      NgxPaginationModule,
      routing
  ],
  declarations: [
      AppComponent,
      DashboardComponent,
      LoginComponent,
      CoursesComponent, 
      PersonComponent, 
      RoomComponent, 
      RatingComponent,
      TrackSessionComponent, 
      TrackComponent
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
      Configuration,
      CourseService,
      PersonService,
      RoomService,
      RatingService,
      TrackSessionService,
      SessionAttendeeService,
      TrackService,
      AuthenticationService,
      AuthGuard
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
