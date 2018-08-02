import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Room } from '../Models/room';
import { RoomService } from '../Services/room.service';
import { first } from 'rxjs/operators';
@Component({
  selector: 'my-rooms',
  templateUrl: '../Views/room.component.html',
  styleUrls: ['../CSS/app.component.css']
})
export class RoomComponent implements OnInit {
 rooms: Room[] = [];
 newRoom: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private roomService: RoomService) {
  }

  ngOnInit(): void {
       this.roomService.getRooms().pipe(first())
            .subscribe(
            value => this.rooms = value
            );

         this.newRoom = this.formBuilder.group({
            name: ['', [Validators.required]],
            description: [''],
            maxOccupancy: ['']
        });
  }

    createRoom({ value, valid }: {value: Room, valid: boolean}) {
      this.roomService.create(value).pipe(first())
      .subscribe(() => {
          this.loadAllRooms();
      });
      this.newRoom.reset();
  }

  loadAllRooms() {
    this.roomService.getRooms().pipe(first()).subscribe(rooms => { 
        this.rooms = rooms; 
    });
  }
}