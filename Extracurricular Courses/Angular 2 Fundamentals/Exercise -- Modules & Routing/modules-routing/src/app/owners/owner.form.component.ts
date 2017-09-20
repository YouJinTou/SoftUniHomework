import { Component } from '@angular/core';
import { Owner } from './../store/owner';

@Component({
    selector: 'add-owner-form',
    templateUrl: './owner.form.component.html',
})

export class AddOwnerFormComponent {
    owner: Owner

    constructor() {
        this.owner = new Owner(null, '', '', null, null);
    }

    onSubmit() {
        console.log(this.owner);
    }
}