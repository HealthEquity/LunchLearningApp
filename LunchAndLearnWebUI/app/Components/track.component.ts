import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
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
 newTrack: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private trackService: TrackService) {
  }

  ngOnInit(): void {
       this.trackService.getTracks()
            .subscribe(
            value => this.tracks = value
            );

        this.newTrack = this.formBuilder.group({
        trackName: ['', [Validators.required]],
        trackDescription: [''],
        isActive: ['']
        });
  }

    createTrack({ value, valid }: {value: Track, valid: boolean}) {
      this.trackService.create(value)
      .subscribe(
      value => this.tracks.push(value));
      this.newTrack.reset();
  }
//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}