import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './Components/dashboard.component';
import { ClassesComponent }      from './Components/classes.component';
import { InstructorComponent }  from './Components/instructor.component';
import { TrackComponent }  from './Components/track.component';
import { RoomComponent }  from './Components/room.component';
import { ScheduleComponent }  from './Components/schedule.component';
import { RatingComponent }  from './Components/rating.component';
import { LoginComponent } from './Components/login.component';
import { AuthGuard } from './Guards/auth.guard';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/classes',
    pathMatch: 'full' 
  },
  {
    path: 'login',
    component: LoginComponent
  },
  { 
    path: 'dashboard',  
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'classes',
    component: ClassesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'instructors',
    component: InstructorComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'tracks',
    component: TrackComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms',
    component: RoomComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'schedules',
    component: ScheduleComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'ratings',
    component: RatingComponent,
    //canActivate: [AuthGuard]
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