import { Component } from '@angular/core';
import { ClassService } from '../Services/class.service'

@Component({
  moduleId: module.id,
  selector: 'my-app',
  template: `
    <h1>{{title}}</h1>
    <div class="header-bar"></div>
    <nav class="navbar navbar-default">
      <a routerLink="/classes" routerLinkActive="active">Classes</a>
      <a routerLink="/instructors" routerLinkActive="active">Instructors</a>
      <a routerLink="/tracks" routerLinkActive="active">Tracks</a>
      <a routerLink="/rooms" routerLinkActive="active">Rooms</a>
      <a routerLink="/schedules" routerLinkActive="active">Schedules</a>
      <a routerLink="/ratings" routerLinkActive="active">Ratings</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  providers: [ClassService],
  styleUrls: ['../CSS/app.component.css']
})
export class AppComponent {
  title = 'Lunch and Learn Classes';
}