import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Room } from '../Models/room';
import { RoomService } from '../Services/room.service';

@Component({
  moduleId: module.id,
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
       this.roomService.getRooms()
            .subscribe(
            value => this.rooms = value
            );

         this.newRoom = this.formBuilder.group({
            roomName: ['', [Validators.required]],
            roomDescription: ['']
        });
  }

    createRoom({ value, valid }: {value: Room, valid: boolean}) {
      this.roomService.create(value)
      .subscribe(
      value => this.rooms.push(value));
      this.newRoom.reset();
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}