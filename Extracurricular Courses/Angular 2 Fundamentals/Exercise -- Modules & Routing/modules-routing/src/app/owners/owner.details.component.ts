import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Data } from './../store/Data';
import { Owner } from './../store/owner';
import { Car } from './../store/car';

@Component({
    selector: 'owner-details',
    templateUrl: './owner.details.component.html'
})

export class OwnerDetailsComponent implements OnInit {
    owner: Owner;

    constructor(private service: Data, private route: ActivatedRoute) { }

    ngOnInit() {
        let ownerId = this.route.snapshot.paramMap.get('id');

        this.service
            .getOwnerById(parseInt(ownerId))
            .then(owner => {
                this.owner = owner;
                console.log(ownerId, this.owner.id)
                this.service
                    .getCarsByOwnerId(this.owner.id)
                    .then(cars => this.owner.cars = cars);
            });
    }
}