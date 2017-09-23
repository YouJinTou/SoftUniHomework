import { Component } from '@angular/core';
import { Car } from './../store/Car';

@Component({
    selector: 'add-car-form',
    templateUrl: './car.form.component.html',
})

export class AddCarFormComponent {
    car: Car

    constructor() {
        this.car = new Car(0, '', '', '', '', null, null, '', null, null)
    }

    onSubmit() {
        console.log(this.car);
    }
}