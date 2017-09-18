import { Owner } from './owner';

export class Car {
    constructor(
        public id: number,
        public make: string,
        public model: string,
        public image: string,
        public description: string,
        public owner: Owner,
        public price: number,
        public engine: string,
        public comments: string[],
        public listingDate: Date
    ) { }
}