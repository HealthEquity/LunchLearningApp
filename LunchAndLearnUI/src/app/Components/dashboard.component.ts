import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TrackSession } from '../Models/tracksession';
import { TrackSessionService } from '../Services/trackSession.service';

import { SessionAttendee} from '../Models/sessionAttendee';
import { SessionAttendeeService } from '../Services/sessionAttendee.service';
import { first } from 'rxjs/operators';
@Component({
  selector: 'my-dashboard',
  templateUrl: '../Views/dashboard.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class DashboardComponent implements OnInit {
  upcomingtracksessions: TrackSession[] = [];
  mytracksessions: TrackSession[] = [];
  personId: number;

  constructor(
    private router: Router,
    private trackSessionService: TrackSessionService,
    private sessionAttendeeService: SessionAttendeeService) {
  }

  ngOnInit(): void {
       this.trackSessionService.getUpcomingTrackSessions().pipe(first())
            .subscribe(
            value => this.upcomingtracksessions = value
            );

       this.trackSessionService.getMyTrackSessions(this.personId).pipe(first())
            .subscribe(
              value => this.mytracksessions = value
            );
  }

  enroll({ value, valid } : {value: SessionAttendee, valid: boolean}) {
    this.sessionAttendeeService.enroll(value).pipe(first())
    .subscribe();
  }

  unenroll({ value, valid } : {value: SessionAttendee, valid: boolean}) {
    this.sessionAttendeeService.unenroll(value.id).pipe(first())
    .subscribe();
  }
}
