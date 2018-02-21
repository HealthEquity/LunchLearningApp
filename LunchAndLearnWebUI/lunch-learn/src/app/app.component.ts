import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Lunch and Learning App';
  position = 'right';

    sidenavItems = [
      { name: 'Home', icon: 'home', route: '/' },
      { name: 'Processing', icon: 'autorenew', route: '' },
      { name: 'Efficiency', icon: 'done_all', route: '' },
      { name: 'Loyalty', icon: 'adb', route: '' },
      { name: 'BOB SLA(s)', icon: 'multiline_chart', route: '' },
      { name: 'Fraud', icon: 'money_off', route: '' },
      { name: 'Risks', icon: 'people', route: '' },
      { name: 'Projects', icon: 'playlist_add_check', route: '' },
      { name: 'Metrics Entry', icon: 'show_chart', route: '' }
    ];
}
