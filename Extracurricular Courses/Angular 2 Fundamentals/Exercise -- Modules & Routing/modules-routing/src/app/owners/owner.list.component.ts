import { Component } from '@angular/core';
import { Data } from './../store/Data';
import { Owner } from './../store/owner';

@Component({
    selector: 'owner-list',
    templateUrl: './owner.list.component.html'
})

export class OwnerListComponent {
    owners: Owner[];
    sortBy: string;
    sortDir: string;
    skip: number;
    showPrevPaging: boolean;
    showNextPaging: boolean;

    private pageSize: number;

    constructor(private service: Data) {
        this.skip = 0;
        this.showPrevPaging = false;
        this.showNextPaging = true;
        this.pageSize = 2;
    }

    ngOnInit() {
        this.loadOwners();
    }

    onSortingRequired(sortBy: string) {
        this.sortBy = sortBy;
        this.sortDir = (this.sortDir === 'desc') ? 'asc' : 'desc';

        this.loadOwners();
    }

    onPrevClicked() {
        this.skip--;
        this.showNextPaging = true;
        this.showPrevPaging = (this.skip >= 1);

        this.loadOwners();
    }

    onNextClicked() {
        this.skip++;
        this.showPrevPaging = true;

        this.loadOwners();
    }

    private loadOwners() {
        this.service
            .getOwners(this.skip * this.pageSize, this.pageSize, this.sortBy, this.sortDir)
            .then(owners => {
                this.owners = owners;
                this.showNextPaging = (this.owners.length == this.pageSize);
            });
    }
}