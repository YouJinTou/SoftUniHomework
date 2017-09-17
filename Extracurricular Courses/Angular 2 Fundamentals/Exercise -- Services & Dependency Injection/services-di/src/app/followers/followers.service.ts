import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { FollowerInfo } from './follower.info';

@Injectable()
export class FollowersService {
  constructor(private http: Http) { }

  getFollowersInfo(profileUrl: string): Promise<FollowerInfo[]> {
    let followersUrl = profileUrl + '/followers';

    return this.http
      .get(followersUrl)
      .toPromise()
      .then(response => response.json() as FollowerInfo[])
      .catch(err => {
        console.log(err);

        return new Array<FollowerInfo>();
      })
  }
}
