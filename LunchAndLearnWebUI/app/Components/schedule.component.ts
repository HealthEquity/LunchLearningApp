import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Schedule } from '../Models/schedule';
import { ScheduleService } from '../Services/schedule.service';

@Component({
  moduleId: module.id,
  selector: 'my-schedules',
  templateUrl: '../Views/schedule.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class ScheduleComponent implements OnInit {
 schedules: Schedule[] = [];
 newSchedule: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private scheduleService: ScheduleService) {
  }

  ngOnInit(): void {
       this.scheduleService.getSchedules()
            .subscribe(
            value => this.schedules = value
            );

      this.newSchedule = this.formBuilder.group({
            classId: ['', [Validators.required]],
            instructorId: ['', [Validators.required]],
            trackId: ['', [Validators.required]],
            classDate: ['', [Validators.required]],
            roomId: ['', [Validators.required]],
        });
  }

   createSchedule({ value, valid }: {value: Schedule, valid: boolean}) {
      this.scheduleService.create(value)
      .subscribe(
      value => this.schedules.push(value));
      this.newSchedule.reset();
  }
}