import { Component, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';

import { CourseDetailsComponent } from '../course-details/course-details.component'

@Component({
  selector: 'll-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent {
  displayedColumns = ['name', 'description'];
  dataSource = new MatTableDataSource<Course>(COURSE_DATA);

  @ViewChild(MatPaginator) paginator: MatPaginator;

  

  /**
   * Set the paginator after the view init since this component will
   * be able to query its view for the initialized paginator.
   */
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(public dialog: MatDialog) { }

  openCourseDialog() {
    const dialogRef = this.dialog.open(CourseDetailsComponent, {
      height: '400px',
      width: '650px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}

export interface Course {
  name: string;
  description: string;
}

const COURSE_DATA: Course[] = [
  { name: 'Test Course 1', description: ''},
  { name: 'Test Course 2', description: ''},
  { name: 'Test Course 3', description: ''},
  { name: 'Test Course 4', description: ''},
];