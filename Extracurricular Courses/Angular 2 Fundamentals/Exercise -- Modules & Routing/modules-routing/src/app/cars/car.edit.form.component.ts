import { Component, OnInit } from '@angular/core';
import { Car } from './../store/Car';
import { ActivatedRoute } from '@angular/router';
import { Data } from './../store/Data';

@Component({
    selector: 'edit-car-form',
    templateUrl: './car.edit.form.component.html',
})

export class EditCarFormComponent implements OnInit {
    car: Car

    constructor(
        private route: ActivatedRoute,
        private service: Data) {
    }

    ngOnInit() {
        let carId = this.route.snapshot.paramMap.get('id'); 

        this.service
            .getCarById(parseInt(carId))
            .then(car => this.car = car);
    }

    onSubmit() {
        console.log(this.car);
    }
}