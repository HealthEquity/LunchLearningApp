import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './Components/dashboard.component';
import { ClassesComponent }      from './Components/classes.component';
import { InstructorComponent }  from './Components/instructor.component';
import { TrackComponent }  from './Components/track.component';
import { RoomComponent }  from './Components/room.component';
import { ScheduleComponent }  from './Components/schedule.component';
import { RatingComponent }  from './Components/rating.component';



const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/classes',
    pathMatch: 'full' 
  },
  { 
    path: 'dashboard',  
    component: DashboardComponent 
  },
  {
    path: 'classes',
    component: ClassesComponent
  },
  {
    path: 'instructors',
    component: InstructorComponent
  },
  {
    path: 'tracks',
    component: TrackComponent
  },
  {
    path: 'rooms',
    component: RoomComponent
  },
  {
    path: 'schedules',
    component: ScheduleComponent
  },
  {
    path: 'ratings',
    component: RatingComponent
  },
    // { path: 'detail/:id', component: HeroDetailComponent },
    // { path: 'heroes',     component: HeroesComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

export const routedComponents = [DashboardComponent];