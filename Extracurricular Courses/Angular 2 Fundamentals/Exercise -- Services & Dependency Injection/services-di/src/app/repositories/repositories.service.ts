import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { RepositoryInfo } from './repository.info';
import { ContributorInfo } from './contributor.info';

@Injectable()
export class RepositoriesService {
  constructor(private http: Http) { }

  getRepositoriesData(apiUrl: string): Promise<RepositoryInfo[]> {
    let repositoriesUrl = apiUrl + '/repos';

    return this.http
      .get(repositoriesUrl)
      .toPromise()
      .then(resp => resp.json() as RepositoryInfo[])
      .catch(err => {
        console.log(err);

        return new Array<RepositoryInfo>();
      });
  }

  getContributorsData(apiUrl: string, repoName: string): Promise<ContributorInfo[]> {
    let repoApiUrl = apiUrl
      .replace("/repos/", "/")
      .replace("/users/", "/repos/");
    let contributorsUrl = repoApiUrl + '/' + repoName + '/contributors';

    return this.http
      .get(contributorsUrl)
      .toPromise()
      .then(resp => resp.json() as ContributorInfo[])
      .catch(err => {
        console.log(err);

        return new Array<ContributorInfo>();
      });
  }
}
