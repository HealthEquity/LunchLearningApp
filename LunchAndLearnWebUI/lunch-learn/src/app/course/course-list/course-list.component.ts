import { Component, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';

import { CourseDetailsComponent } from '../course-details/course-details.component'
import { ClassService } from '../course.service';

@Component({
  selector: 'll-courses',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css'],
  providers: [ClassService]
})
export class CourseListComponent {
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

  constructor(public dialog: MatDialog, private courseService: ClassService) { }

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
  courseId: number;
  courseName: string;
  courseDescription: string;
}

const COURSE_DATA: Course[] = [
  { courseId: 1, courseName: 'Test Course 1', courseDescription: ''},
  { courseId: 2, courseName: 'Test Course 2', courseDescription: ''},
  { courseId: 3, courseName: 'Test Course 3', courseDescription: ''},
  { courseId: 4, courseName: 'Test Course 4', courseDescription: ''},
];