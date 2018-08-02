import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Rating } from '../Models/rating';
import { RatingService } from '../Services/rating.service';
import { first } from 'rxjs/operators';
@Component({
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
       this.RatingService.getRatings().pipe(first())
            .subscribe(
            value => this.ratings = value
            );
  }
}