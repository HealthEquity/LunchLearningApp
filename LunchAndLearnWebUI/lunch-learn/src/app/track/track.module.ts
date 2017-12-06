import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';


import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { TrackDetailsComponent } from './track-details/track-details.component';
import { TrackListComponent } from './track-list/track-list.component';


@NgModule({
    declarations: [
        TrackDetailsComponent,
        TrackListComponent
    ],
    imports: [
      BrowserModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [TrackDetailsComponent, TrackListComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class TrackModule { }
  