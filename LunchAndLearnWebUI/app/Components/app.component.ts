import { Component } from '@angular/core';
import { CourseService } from '../Services/course.service'

@Component({
  moduleId: module.id,
  selector: 'my-app',
  templateUrl: '../Views/menu.component.html',
  providers: [CourseService],
  styleUrls: ['../CSS/app.component.css']
})
export class AppComponent {
  title = 'Lunch and Learn Courses';
}