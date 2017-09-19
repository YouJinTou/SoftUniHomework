import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Data } from './../store/Data';
import { Car } from './../store/car';


@Component({
    selector: 'car-details',
    templateUrl: './car.details.component.html'
})

export class CarDetailsComponent implements OnInit {
    car: Car;

    constructor(
        private route: ActivatedRoute,
        private service: Data) {
    }

    ngOnInit() {
        let carId = this.route.snapshot.paramMap.get('id');

        this.service
            .getCar(parseInt(carId))
            .then(car => this.car = car);
    }
}