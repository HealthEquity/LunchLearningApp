import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TrackSession } from '../Models/tracksession';
import { TrackSessionService } from '../Services/trackSession.service';

import { SessionAttendee} from '../Models/sessionAttendee';
import { SessionAttendeeService } from '../Services/sessionAttendee.service';

@Component({
  moduleId: module.id,
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
       this.trackSessionService.getUpcomingTrackSessions()
            .subscribe(
            value => this.upcomingtracksessions = value
            );

       this.trackSessionService.getMyTrackSessions(this.personId)
            .subscribe(
              value => this.mytracksessions = value
            );
  }

  enroll({ value, valid } : {value: SessionAttendee, valid: boolean}) {
    this.sessionAttendeeService.enroll(value)
    .subscribe();
  }

  unenroll({ value, valid } : {value: SessionAttendee, valid: boolean}) {
    this.sessionAttendeeService.unenroll(value.id)
    .subscribe();
  }
}
