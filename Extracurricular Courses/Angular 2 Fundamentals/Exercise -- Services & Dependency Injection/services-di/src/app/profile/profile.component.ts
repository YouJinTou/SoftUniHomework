import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { ProfileService } from './profile.service';
import { ProfileInfo } from './profile.info';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [ProfileService]
})

export class ProfileComponent implements OnChanges {
  @Input() apiUrl: string;
  profileInfo: ProfileInfo;

  constructor(private service: ProfileService) { }

  ngOnChanges() {
    if (!this.apiUrl) {
      return;
    }
    
    this.service
      .getProfileInfo(this.apiUrl)
      .then(info => {
        this.profileInfo = info;
      });
  }
}
