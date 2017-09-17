import { Component, Input, NgZone } from '@angular/core';
import { RepositoriesService } from './repositories.service';
import { RepositoryInfo } from './repository.info';
import { ContributorInfo } from './contributor.info';

@Component({
  selector: 'repositories',
  templateUrl: './repositories.component.html',
  styleUrls: ['./repositories.component.css'],
  providers: [RepositoriesService]
})

export class RepositoriesComponent {
  @Input() apiUrl: string;
  repositoriesInfo: RepositoryInfo[];
  contributorsInfo: ContributorInfo[];

  constructor(private service: RepositoriesService) { }

  onRepositoriesDataRequired() {
    if (!this.apiUrl) {
      this.repositoriesInfo = new Array<RepositoryInfo>();

      return;
    }

    this.service
      .getRepositoriesData(this.apiUrl)
      .then(info => {
        this.repositoriesInfo = info;
      });
  }

  onRepoContributorsRequired(repo: RepositoryInfo) {
    if (!this.apiUrl) {
      this.contributorsInfo = new Array<ContributorInfo>();

      return;
    }

    this.service
      .getContributorsData(this.apiUrl, repo.name)
      .then(info => {
        this.contributorsInfo = info;
      });
  }
}
