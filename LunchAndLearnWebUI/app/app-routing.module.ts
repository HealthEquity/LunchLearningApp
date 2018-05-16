import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './Components/dashboard.component';
import { CoursesComponent }      from './Components/courses.component';
import { PersonComponent }  from './Components/person.component';
import { TrackComponent }  from './Components/track.component';
import { RoomComponent }  from './Components/room.component';
import { TrackSessionComponent }  from './Components/trackSession.component';
import { RatingComponent }  from './Components/rating.component';
import { LoginComponent } from './Components/login.component';
import { AuthGuard } from './Guards/auth.guard';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/dashboard',
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
    path: 'courses',
    component: CoursesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'persons',
    component: PersonComponent,
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
    path: 'trackSessions',
    component: TrackSessionComponent,
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