import { Component } from '@angular/core';
import { ClassService } from '../Services/class.service'

@Component({
  moduleId: module.id,
  selector: 'my-app',
  templateUrl: '../Views/menu.component.html',
  providers: [ClassService],
  styleUrls: ['../CSS/app.component.css']
})
export class AppComponent {
  title = 'Lunch and Learn Classes';
}