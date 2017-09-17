import { Component, OnInit } from '@angular/core';
import { ProfileService } from './profile.service';
import { ProfileInfo } from './profile.info';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [ProfileService]
})

export class ProfileComponent implements OnInit {
  private apiUrl: string = 'https://api.github.com/users/ivaylokenov';

  profileInfo: ProfileInfo;

  constructor(private service: ProfileService) { }

  ngOnInit() {
    this.service
      .getProfileInfo(this.apiUrl)
      .then(info => {
        this.profileInfo = info;
      });
  }
}
