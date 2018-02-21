import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Rating } from '../Models/rating';
import { RatingService } from '../Services/rating.service';

@Component({
  moduleId: module.id,
  selector: 'my-ratings',
  templateUrl: '../Views/rating.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class RatingComponent implements OnInit {
 ratings: Rating[] = [];

  constructor(
    private router: Router,
    private RatingService: RatingService) {
  }

  ngOnInit(): void {
       this.RatingService.getRatings()
            .subscribe(
            value => this.ratings = value
            );
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}