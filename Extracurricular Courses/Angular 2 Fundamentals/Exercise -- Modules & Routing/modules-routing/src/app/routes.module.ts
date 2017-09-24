import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarListComponent } from './cars/car.list.component';
import { CarDetailsComponent } from './cars/car.details.component';
import { AddCarFormComponent } from './cars/car.form.component';
import { EditCarFormComponent } from './cars/car.edit.form.component';
import { OwnerListComponent } from './owners/owner.list.component';
import { OwnerDetailsComponent } from './owners/owner.details.component';
import { AddOwnerFormComponent } from './owners/owner.form.component';
import { EditOwnerFormComponent } from './owners/owner.edit.form.component';
import { CommentsComponent } from './comments/comments.component';
import { RoundImageDirective } from './directives/round.image.directive';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cars', component: CarListComponent },
    { path: 'cars/add', component: AddCarFormComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
    { path: 'cars/:id/edit', component: EditCarFormComponent },
    { path: 'owners', component: OwnerListComponent },
    { path: 'owners/add', component: AddOwnerFormComponent },
    { path: 'owners/:id', component: OwnerDetailsComponent },
    { path: 'owners/:id/edit', component: EditOwnerFormComponent }
]

@NgModule({
    declarations: [
        HomeComponent,
        CarListComponent,
        CarDetailsComponent,
        AddCarFormComponent,
        EditCarFormComponent,
        OwnerListComponent,
        OwnerDetailsComponent,
        AddOwnerFormComponent,
        EditOwnerFormComponent,
        CommentsComponent,
        RoundImageDirective
    ],
    imports: [
        CommonModule, 
        FormsModule,
        RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }