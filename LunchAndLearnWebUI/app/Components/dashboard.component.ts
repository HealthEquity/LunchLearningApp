import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TrackSession } from '../Models/tracksession';
import { TrackSessionService } from '../Services/trackSession.service';

@Component({
  moduleId: module.id,
  selector: 'my-dashboard',
  templateUrl: '../Views/dashboard.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class DashboardComponent implements OnInit {
  upcomingtracksessions: TrackSession[] = [];
  tracksessions: TrackSession[] = [];

  constructor(
    private router: Router,
    private trackSessionService: TrackSessionService) {
  }

  ngOnInit(): void {
       this.trackSessionService.getUpcomingTrackSessions()
            .subscribe(
            value => this.upcomingtracksessions = value
            );
  }
}