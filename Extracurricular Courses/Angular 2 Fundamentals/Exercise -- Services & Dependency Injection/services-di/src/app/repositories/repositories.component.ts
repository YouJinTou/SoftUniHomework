import { Component, Input } from '@angular/core';
import { RepositoriesService } from './repositories.service';
import { RepositoryInfo } from './repository.info';

@Component({
  selector: 'repositories',
  templateUrl: './repositories.component.html',
  styleUrls: ['./repositories.component.css'],
  providers: [RepositoriesService]
})
export class RepositoriesComponent {
  @Input() apiUrl: string;
  repositoriesInfo: RepositoryInfo[];

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
}
