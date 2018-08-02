import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Track } from '../Models/track';
import { TrackService } from '../Services/track.service';
import { first } from 'rxjs/operators';
@Component({
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
       this.trackService.getTracks().pipe(first())
            .subscribe(
            value => this.tracks = value
            );

        this.newTrack = this.formBuilder.group({
        name: ['', [Validators.required]],
        description: [''],
        seasonNr: ['']
        });
  }

    createTrack({ value, valid }: {value: Track, valid: boolean}) {
      this.trackService.create(value).pipe(first())
      .subscribe(() => {
          this.loadAllTracks();
      });
      this.newTrack.reset();
  }

  loadAllTracks() {
    this.trackService.getTracks().pipe(first()).subscribe(tracks => { 
        this.tracks = tracks; 
    });
  }

}