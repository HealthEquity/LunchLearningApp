import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Track } from '../Models/track';
import { TrackService } from '../Services/track.service';

@Component({
  moduleId: module.id,
  selector: 'my-tracks',
  templateUrl: '../Views/track.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class TrackComponent implements OnInit {
 tracks: Track[] = [];

  constructor(
    private router: Router,
    private TrackService: TrackService) {
  }

  ngOnInit(): void {
       this.TrackService.getTracks()
            .subscribe(
            value => this.tracks = value
            );
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}