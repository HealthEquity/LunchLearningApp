import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';


import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { SessionDetailsComponent } from '../session/session-details/session-details.component';
import { SessionListComponent } from '../session/session-list/session-list.component';


@NgModule({
    declarations: [
        SessionDetailsComponent,
        SessionListComponent
    ],
    imports: [
      BrowserModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [SessionDetailsComponent, SessionListComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class SessionModule { }
  