import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(
    private router: Router,
    private RoomService: RoomService) {
  }

  ngOnInit(): void {
       this.RoomService.getRooms()
            .subscribe(
            value => this.rooms = value
            );
  }

//   gotoDetail(hero: Hero): void {
//     let link = ['/detail', hero.id];
//     this.router.navigate(link);
//   }
}