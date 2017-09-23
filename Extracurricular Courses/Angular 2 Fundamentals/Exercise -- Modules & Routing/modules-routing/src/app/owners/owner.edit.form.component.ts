import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Data } from './../store/Data';
import { Owner } from './../store/Owner';

@Component({
    selector: 'edit-owner-form',
    templateUrl: './owner.edit.form.component.html',
})

export class EditOwnerFormComponent {
    owner: Owner

    constructor(private service: Data, private route: ActivatedRoute) {
        let ownerId = this.route.snapshot.paramMap.get('id');

        this.service
            .getOwnerById(parseInt(ownerId))
            .then(owner => {
                this.owner = owner;
            });
    }

    onSubmit() {
        console.log(this.owner);
    }
}