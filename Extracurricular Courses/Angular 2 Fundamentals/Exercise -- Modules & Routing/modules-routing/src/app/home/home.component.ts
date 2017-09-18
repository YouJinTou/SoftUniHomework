import { Component, OnInit } from '@angular/core';
import { Data } from './../store/Data';
import { Car } from './../store/Car';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [Data]
})

export class HomeComponent implements OnInit {
  cars: Car[];

  constructor(private service: Data) { }

  ngOnInit() {
    this.service
      .getCars()
      .then(cars => {
        console.log(cars)
        this.cars = cars
          .sort((a, b) => b.listingDate.getTime() - a.listingDate.getTime())
          .slice(0, 6);
      });
  }
}
