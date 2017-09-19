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
                new Owner(1, 'Ivan', 'Ivanov', [], []),
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
                new Owner(1, 'Ivan', 'Ivanov', [], []),
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
                new Owner(1, 'Ivan', 'Ivanov', [], []),
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
                new Owner(2, 'John', 'Doe', [], []),
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
                new Owner(3, 'John', 'Doe', [], []),
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
                new Owner(4, 'Who', 'Doneit', [], []),
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
                new Owner(5, 'Merry', 'Poppins', [], []),
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
                new Owner(6, 'Dragan', 'Jovtchev', [], []),
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
                new Owner(7, 'Asen', 'Milenov', [], []),
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
                new Owner(7, 'Asen', 'Milenov', [], []),
                4212,
                'V1',
                ['Bad car', 'Not so good'],
                new Date('February 4, 2011 10:13:00')),
        );

        return new Promise<Car[]>((resolve, reject) => {
            setTimeout(function () {
                skip = skip ? skip : 0;
                take = take ? take : cars.length;
                cars = cars.slice(skip, skip + take);

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

                cars = (sortDir === 'asc') ? cars : cars.reverse();

                resolve(cars);
            }, 0);
        });
    }

    getCarById(id: number): Promise<Car> {
        return this.getCars().then(res => res.find(c => c.id === id));
    }

    getCarsByOwnerId(id: number): Promise<Car[]> {
        return this.getCars().then(res => res.filter(c => c.owner.id === id));
    }

    getOwners(skip?: number, take?: number, sortBy?: string, sortDir?: string): Promise<Owner[]> {
        return new Promise<Owner[]>((resolve, reject) => {
            setTimeout(function () {
                let owners = new Array<Owner>(
                    new Owner(1, 'Ivan Ivanov', './../../assets/ivan-ivanov.jpg', [1, 2, 3], []),
                    new Owner(2, 'John Doe', './../../assets/john-doe.jpg', [4], []),
                    new Owner(3, 'Jane Hopkins', './../../assets/jane-hopkins.jpg', [5], []),
                    new Owner(4, 'Who Doneit', './../../assets/john-doe.jpg', [6], []),
                    new Owner(5, 'Merry Popins', './../../assets/jane-hopkins.jpg', [7], []),
                    new Owner(6, 'Dragan Jovtchev', './../../assets/ivan-ivanov.jpg', [8], []),
                    new Owner(7, 'Asen Milenov', './../../assets/john-doe.jpg', [9, 10], []),
                );

                owners.forEach(o => {
                    o.carIds.forEach(id =>
                        () => {
                            this.getCarById(id).then(c => o.cars.push(c));
                        }
                    );
                });

                switch (sortBy) {
                    case 'name':
                        owners = owners.sort(
                            (a, b) => (a.name < b.name) ? -1 : a.name > b.name ? 1 : 0);
                    default:
                        break;
                }

                skip = skip ? skip : 0;
                take = take ? take : owners.length;
                owners = (sortDir === 'desc') ?
                    owners.reverse().slice(skip, skip + take) :
                    owners.slice(skip, skip + take);

                resolve(owners);
            }, 0);
        });
    }

    getOwnerById(id: number): Promise<Owner> {
        return this.getOwners().then(res => res.find(o => o.id === id));
    }
}