import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import './rxjs-extensions';
import { DashboardComponent} from './dashboard.component';
import { AppComponent }         from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ClassService }          from './Services/class.service';
import { Configuration } from './app.constants';
import {APP_BASE_HREF} from '@angular/common';

@NgModule({
  imports:      [ 
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule, 
    ],
  declarations: [ AppComponent, DashboardComponent ],
  providers: [ {provide: APP_BASE_HREF, useValue : '/' },
    ClassService, Configuration
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
