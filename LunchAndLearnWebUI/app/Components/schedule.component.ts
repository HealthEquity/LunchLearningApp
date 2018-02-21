import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Schedule } from '../Models/schedule';
import { DbClass } from '../Models/dbClass';
import { Room } from '../Models/room';
import { Track } from '../Models/track';
import { Instructor } from '../Models/instructor';
import { ScheduleService } from '../Services/schedule.service';
import { ClassService } from '../Services/class.service';
import { RoomService } from '../Services/room.service';
import { TrackService } from '../Services/track.service';
import { InstructorService } from '../Services/instructor.service';

@Component({
  moduleId: module.id,
  selector: 'my-schedules',
  templateUrl: '../Views/schedule.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class ScheduleComponent implements OnInit {
 schedules: Schedule[] = [];
 classesList: DbClass[] = [];
 roomList: Room[] = [];
 trackList: Track[] = [];
 instructorList: Instructor[] = [];
 newSchedule: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private scheduleService: ScheduleService,
    private classService: ClassService,
    private roomService: RoomService,
    private trackService: TrackService,
    private instructorService: InstructorService) {
  }

  ngOnInit(): void {
      this.getSchedules();

      this.classService.getClasses()
      .subscribe(value => this.classesList = value);

       this.roomService.getRooms()
      .subscribe(value => this.roomList = value);

       this.trackService.getTracks()
      .subscribe(value => this.trackList = value);

       this.instructorService.getInstructors()
      .subscribe(value => this.instructorList = value);

      this.newSchedule = this.formBuilder.group({
            classId: ['', [Validators.required]],
            instructorId: ['', [Validators.required]],
            trackId: ['', [Validators.required]],
            classDate: ['', [Validators.required]],
            roomId: ['', [Validators.required]],
        });
  }

  getSchedules()
  {
    this.scheduleService.getSchedules()
            .subscribe(value => this.schedules = value);
  }

   createSchedule({ value, valid }: {value: Schedule, valid: boolean}) {
      this.scheduleService.create(value)
      .subscribe(
      value => this.schedules.push(value));
      this.newSchedule.reset();
  }

  updateSchedule(schedule) {
      this.scheduleService.update(schedule)
      .subscribe();
      this.getSchedules();
  }
}