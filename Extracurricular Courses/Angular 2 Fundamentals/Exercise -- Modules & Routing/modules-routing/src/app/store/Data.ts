import { Injectable } from '@angular/core';
import { Car } from './Car';
import { Owner } from './Owner';
import 'rxjs/add/operator/toPromise';

export class Data {
    getCars(skip?: number, take?: number, sortBy?: string, sortDir?: string): Promise<Car[]> {
        let cars = new Array<Car>(
            new Car(
                1,
                'FORD',
                'Escort',
                './../../assets/ford-escort.jpg',
                'Cool car',
                new Owner(1, 'Ivan', 'Ivanov'),
                1234,
                'V2',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2001 10:13:00')),
            new Car(
                2,
                'CHRYSLER',
                'Renegade',
                './../../assets/chrysler-renegade.jpg',
                'Bought it a year ago.',
                new Owner(1, 'Ivan', 'Ivanov'),
                4912,
                'V8',
                ['AWESOME', 'The one and only', 'WTF...'],
                new Date('February 9, 2012 10:13:00')),
            new Car(
                3,
                'CITROEN',
                'Berlingo',
                './../../assets/citroen-berlingo.jpg',
                'Not the best, but will work for most.',
                new Owner(1, 'Ivan', 'Ivanov'),
                3341,
                'V4',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2006 10:13:00')),
            new Car(
                4,
                'DACIA',
                'Duster',
                './../../assets/dacia-duster.jpg',
                'ROMANIA, baby!',
                new Owner(2, 'John', 'Doe'),
                8123,
                'V6',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2007 10:13:00')),
            new Car(
                5,
                'FIAT',
                '500',
                './../../assets/fiat-500.jpg',
                'Okay, this Italian buddy will take you anywhere.',
                new Owner(2, 'John', 'Doe'),
                1234,
                'V8',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2008 10:13:00')),
            new Car(
                6,
                'HYUNDAI',
                'i10',
                './../../assets/huyndai-i10.jpg',
                'Not sure what you would pay for it, but I would cough up.',
                new Owner(2, 'John', 'Doe'),
                1234,
                'V5',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2010 10:13:00')),
            new Car(
                7,
                'KIA',
                'Carens',
                './../../assets/kia-carens.jpg',
                'Here comes the KIA.',
                new Owner(3, 'Jane', 'Hopkins'),
                8123,
                'V2',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2001 10:13:00')),
            new Car(
                8,
                'MERCEDES',
                'Vito',
                './../../assets/mercedes-vito.jpg',
                'Germany for life.',
                new Owner(3, 'Jane', 'Hopkins'),
                5123,
                'V2',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2001 10:13:00')),
            new Car(
                9,
                'MITSUBISHI',
                'Mirage',
                './../../assets/mitsubishi-mirage.jpg',
                'Japanese automakers are good!',
                new Owner(3, 'Jane', 'Hopkins'),
                3771,
                'V2',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2012 10:13:00')),
            new Car(
                10,
                'PEUGEOT',
                '208',
                './../../assets/peugeot-208.jpg',
                'The French make good cars. Buy this one.',
                new Owner(3, 'Jane', 'Hopkins'),
                4212,
                'V1',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2011 10:13:00')),
        );

        return new Promise<Car[]>((resolve, reject) => {
            setTimeout(function () {
                switch (sortBy) {
                    case 'make':
                        cars = cars.sort(
                            (a, b) => (a.make < b.make) ? -1 : a.make > b.make ? 1 : 0);
                        break;

                    case 'owner':
                        cars = cars.sort(
                            (a, b) => (a.owner.name < b.owner.name) ? -1 :
                                a.owner.name > b.owner.name ? 1 : 0);
                        break;

                    case 'date':
                        cars = cars.sort(
                            (a, b) => (a.listingDate < b.listingDate) ? -1 : a.listingDate > b.listingDate ? 1 : 0);
                        break;

                    default:
                        break;
                }

                skip = skip ? skip : 0;
                take = take ? take : cars.length;
                cars = (sortDir === 'desc') ?
                    cars.reverse().slice(skip, skip + take) :
                    cars.slice(skip, skip + take);

                resolve(cars);
            }, 1000);
        });
    }

    getCar(id: number): Promise<Car> {
        return this.getCars().then(res => res.find(c => c.id === id));
    }

    getOwners(): Promise<Owner[]> {
        return new Promise<Owner[]>((resolve, reject) => {
            setTimeout(function () {
                resolve(new Array<Owner>(
                    new Owner(1, 'Ivan Ivanov', './../../assets/ivan-ivanov.jpg'),
                    new Owner(2, 'John Doe', './../../assets/john-doe.jpg'),
                    new Owner(3, 'Jane Hopkins', './../../assets/jane-hopkins.jpg')
                ))
            }, 1000);
        });
    }

    getOwnerById(id: number): Promise<Owner> {
        return this.getOwners().then(res => res.find(o => o.id === id));
    }
}