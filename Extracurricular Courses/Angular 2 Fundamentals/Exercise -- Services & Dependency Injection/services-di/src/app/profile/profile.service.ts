import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { ProfileInfo } from './profile.info';

@Injectable()
export class ProfileService {
  constructor(private http: Http) { }

  getProfileInfo(profileUrl: string): Promise<ProfileInfo> {
    return this.http
      .get(profileUrl)
      .toPromise()
      .then(response => response.json() as ProfileInfo)
      .catch(err => {
        console.log(err);

        return new ProfileInfo();
      })
  }
}
