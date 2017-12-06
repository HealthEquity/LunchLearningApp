import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppRoutingModule } from './app.routing.module';
import { CustomMaterialModule } from './custom-material.module';
import { CoreModule } from './core/core.module';
import { CourseModule } from './course/course.module';
import { PersonModule } from './person/person.module';
import { RoomModule } from './room/room.module';
import { SessionModule } from './session/session.module';
import { TrackModule } from './track/track.module'
 
import { AppComponent } from './app.component';
import { PersonSignupComponent } from './person/person-signup/person-signup.component';
import { PersonLoginComponent } from './person/person-login/person-login.component';
import { CourseDetailsComponent} from './course/course-details/course-details.component';




@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CustomMaterialModule,
    AppRoutingModule,
    CoreModule,
    CourseModule,
    PersonModule,
    RoomModule,
    SessionModule,
    TrackModule
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
