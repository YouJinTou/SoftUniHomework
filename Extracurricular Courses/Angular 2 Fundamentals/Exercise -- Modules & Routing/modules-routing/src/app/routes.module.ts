import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarListComponent } from './cars/car.list.component';
import { CarDetailsComponent } from './cars/car.details.component';
import { AddCarFormComponent } from './cars/car.form.component';
import { OwnerListComponent } from './owners/owner.list.component';
import { OwnerDetailsComponent } from './owners/owner.details.component';
import { AddOwnerFormComponent } from './owners/owner.form.component';
import { CommentsComponent } from './comments/comments.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cars', component: CarListComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
    { path: 'cars/add', component: AddCarFormComponent },
    { path: 'owners', component: OwnerListComponent },
    { path: 'owners/:id', component: OwnerDetailsComponent },
    { path: 'owners/add', component: AddOwnerFormComponent }
]

@NgModule({
    declarations: [
        HomeComponent,
        CarListComponent,
        CarDetailsComponent,
        AddCarFormComponent,
        OwnerListComponent,
        OwnerDetailsComponent,
        AddOwnerFormComponent,
        CommentsComponent
    ],
    imports: [
        CommonModule, 
        FormsModule,
        RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }