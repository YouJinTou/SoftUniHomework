import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarListComponent } from './cars/car.list.component';
import { CarDetailsComponent } from './cars/car.details.component';
import { OwnerListComponent } from './owners/owner.list.component';
import { OwnerDetailsComponent } from './owners/owner.details.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cars', component: CarListComponent },
    { path: 'cars/:id', component: CarDetailsComponent },
    { path: 'owners', component: OwnerListComponent },
    { path: 'owners/:id', component: OwnerDetailsComponent }
]

@NgModule({
    declarations: [
        HomeComponent,
        CarListComponent,
        CarDetailsComponent,
        OwnerListComponent,
        OwnerDetailsComponent
    ],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }