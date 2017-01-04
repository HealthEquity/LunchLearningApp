import { Component } from '@angular/core';
import { ClassService } from './Services/class.service'

@Component({
  moduleId: module.id,
  selector: 'my-app',
  template: `
    <h1>{{title}}</h1>
    <div class="header-bar"></div>
    <nav>
      <a routerLink="/dashboard" routerLinkActive="active">Dashboard</a>
      <a routerLink="/instructors" routerLinkActive="active">Instructors</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  providers: [ClassService],
  styleUrls: ['app.component.css']
})
export class AppComponent {
  title = 'Lunch and Learn Classes';
}