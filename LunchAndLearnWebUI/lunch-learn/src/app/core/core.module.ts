import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';


import { CustomMaterialModule } from '../custom-material.module';
import { AppRoutingModule } from '../app.routing.module';
import { NavigationComponent } from '../core/navigation/navigation.component';
import { PageNotFoundComponent } from '../core/page-not-found/page-not-found.component';


@NgModule({
    declarations: [
        NavigationComponent,
        PageNotFoundComponent
    ],
    imports: [
      BrowserModule,
      CustomMaterialModule,
      AppRoutingModule
    ],
    exports: [NavigationComponent, PageNotFoundComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
  })
  export class CoreModule { }
  