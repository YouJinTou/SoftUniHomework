import { Component, Output } from '@angular/core';
import { ProfileComponent } from './profile/profile.component'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  profileUrl: string;

  fetchProfileData(url: string) {
    this.profileUrl = url;
  }
}
