import { Component, Input } from '@angular/core';
import { FollowersService } from './followers.service';
import { FollowerInfo } from './follower.info';

@Component({
  selector: 'followers',
  templateUrl: './followers.component.html',
  styleUrls: ['./followers.component.css'],
  providers: [FollowersService]
})
export class FollowersComponent {
  @Input() apiUrl: string;
  followersInfo: FollowerInfo[];

  constructor(private service: FollowersService) { }

  onFollowersInfoRequired() {
    if (!this.apiUrl) {
      this.followersInfo = new Array<FollowerInfo>();

      return;
    }

    this.service
      .getFollowersInfo(this.apiUrl)
      .then(info => {
        this.followersInfo = info.slice(0, 10);
      })
  }
}
