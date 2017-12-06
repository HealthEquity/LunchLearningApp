import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';


import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { RoomDetailsComponent } from '../room/room-details/room-details.component';
import { RoomListComponent } from '../room/room-list/room-list.component';


@NgModule({
    declarations: [
        RoomDetailsComponent,
        RoomListComponent
    ],
    imports: [
      BrowserModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [RoomDetailsComponent, RoomListComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class RoomModule { }
  