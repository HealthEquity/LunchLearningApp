import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CourseListComponent } from './course/course-list/course-list.component'
import { RoomListComponent } from './room/room-list/room-list.component'
import { SessionListComponent } from './session/session-list/session-list.component'
import { TrackListComponent } from './track/track-list/track-list.component'
import { PersonListComponent } from './person/person-list/person-list.component'
import { PageNotFoundComponent } from './core/page-not-found/page-not-found.component'


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '' },
  { path: 'courses', component: CourseListComponent },
  { path: 'rooms', component: RoomListComponent },
  { path: 'sessions', component: SessionListComponent },
  { path: 'tracks', component: TrackListComponent },
  { path: 'users', component: PersonListComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

export const routingComponents = [
  CourseListComponent,
  RoomListComponent,
  SessionListComponent,
  TrackListComponent,
  PersonListComponent,
  PageNotFoundComponent
];  