import { Component, OnInit } from '@angular/core';
import { Data } from './../store/Data';
import { Car } from './../store/Car';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: []
})

export class HomeComponent implements OnInit {
  cars: Car[];

  constructor(private service: Data) { }

  ngOnInit() {
    this.service
      .getCars(0, 6, 'date', 'desc')
      .then(cars => this.cars = cars);
  }
}
