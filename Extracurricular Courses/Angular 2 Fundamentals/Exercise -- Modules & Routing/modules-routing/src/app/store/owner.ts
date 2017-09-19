import { Car } from './car';

export class Owner {
    constructor(
        public id: number, 
        public name: string, 
        public image: string,
        public carIds: number[],
        public cars: Car[]) { }
}