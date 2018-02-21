import { NgModule } from '@angular/core';  
import { Routes, RouterModule } from '@angular/router';

import { CoursesComponent } from './courses/courses.component'
import { RoomsComponent } from './rooms/rooms.component'
import { SessionsComponent } from './sessions/sessions.component'
import { TracksComponent } from './tracks/tracks.component'
import { PersonsComponent } from './persons/persons.component'
import { PageNotFoundComponent } from './page-not-found/page-not-found.component'


const routes: Routes = [  
    { path: '', pathMatch: 'full', redirectTo: '' },
    { path: 'courses', component: CoursesComponent },
    { path: 'rooms', component: RoomsComponent },
    { path: 'sessions', component: SessionsComponent },
    { path: 'tracks', component: TracksComponent },
    { path: 'users', component: PersonsComponent },
    { path: '**', component: PageNotFoundComponent }
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
  })
  export class AppRoutingModule { }
  
  export const routingComponents = [
      CoursesComponent,
      RoomsComponent,
      SessionsComponent,
      TracksComponent,
      PersonsComponent,
      PageNotFoundComponent
    ];  