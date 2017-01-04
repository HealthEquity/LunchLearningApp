import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DbClass } from './Models/dbClass';
import { ClassService } from './Services/class.service';

@Component({
  moduleId: module.id,
  selector: 'my-dashboard',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  classes: DbClass[] = [];

  constructor(
    private router: Router,
    private classService: ClassService) {
  }

  ngOnInit(): void {
    this.classService.getClasses()
      .then(classes => this.classes = classes.slice(1, 5));
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}