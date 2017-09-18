import { Component, OnInit } from '@angular/core';
import { Data } from './../store/Data';
import { Car } from './../store/Car';

@Component({
    selector: 'car-list',
    templateUrl: './car.list.component.html'
})

export class CarListComponent implements OnInit {
    cars: Car[];
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
        this.pageSize = 3;
    }

    ngOnInit() {
        this.loadCars();
    }

    onSortingRequired(sortBy: string) {
        this.sortBy = sortBy;
        this.sortDir = (this.sortDir === 'desc') ? 'asc' : 'desc';

        this.loadCars();
    }

    onPrevClicked() {
        this.skip--;
        this.showNextPaging = true;
        this.showPrevPaging = (this.skip >= 1);

        this.loadCars();
    }

    onNextClicked() {
        this.skip++;
        this.showPrevPaging = true;

        this.loadCars();
    }

    private loadCars() {
        this.service
            .getCars(this.skip * this.pageSize, this.pageSize, this.sortBy, this.sortDir)
            .then(cars => {
                this.cars = cars;
                this.showNextPaging = (this.cars.length == this.pageSize);
            });
    }
}