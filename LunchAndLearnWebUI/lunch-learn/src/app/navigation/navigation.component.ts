import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { PersonLoginComponent } from '../person-login/person-login.component';
import { PersonSignupComponent } from '../person-signup/person-signup.component';

@Component({
  selector: 'll-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  openLoginDialog() {
    const dialogRef = this.dialog.open(PersonLoginComponent, {
      height: '340px',
      width: '350px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openSignUpDialog() {
    const signUpDialogRef = this.dialog.open(PersonSignupComponent, {
      height: '500px',
      width: '350px',
    });

    signUpDialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit() {
  }

}
