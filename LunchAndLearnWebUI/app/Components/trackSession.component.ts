import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { TrackSession } from '../Models/trackSession';
import { Course } from '../Models/course';
import { Room } from '../Models/room';
import { Track } from '../Models/track';
import { Person } from '../Models/person';
import { TrackSessionService } from '../Services/trackSession.service';
import { CourseService } from '../Services/course.service';
import { RoomService } from '../Services/room.service';
import { TrackService } from '../Services/track.service';
import { PersonService } from '../Services/person.service';

@Component({
  moduleId: module.id,
  selector: 'my-trackSessions',
  templateUrl: '../Views/trackSession.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class TrackSessionComponent implements OnInit {
 trackSessions: TrackSession[] = [];
 coursesList: Course[] = [];
 roomList: Room[] = [];
 trackList: Track[] = [];
 personList: Person[] = [];
 newTrackSession: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private trackSessionService: TrackSessionService,
    private courseService: CourseService,
    private roomService: RoomService,
    private trackService: TrackService,
    private personService: PersonService) {
  }

  ngOnInit(): void {
      this.getTrackSessions();

      this.courseService.getCourses()
      .subscribe(value => this.coursesList = value);

       this.roomService.getRooms()
      .subscribe(value => this.roomList = value);

       this.trackService.getTracks()
      .subscribe(value => this.trackList = value);

       this.personService.getPersons()
      .subscribe(value => this.personList = value);

      this.newTrackSession = this.formBuilder.group({
            courseId: ['', [Validators.required]],
            personId: ['', [Validators.required]],
            trackId: ['', [Validators.required]],
            courseDate: ['', [Validators.required]],
            roomId: ['', [Validators.required]],
        });
  }

  getTrackSessions()
  {
    this.trackSessionService.getTrackSessions()
            .subscribe(value => this.trackSessions = value);
  }

   createTrackSession({ value, valid }: {value: TrackSession, valid: boolean}) {
      this.trackSessionService.create(value)
      .subscribe(
      value => this.trackSessions.push(value));
      this.newTrackSession.reset();
  }

  updateTrackSession(trackSession) {
      this.trackSessionService.update(trackSession)
      .subscribe();
      this.getTrackSessions();
  }
}