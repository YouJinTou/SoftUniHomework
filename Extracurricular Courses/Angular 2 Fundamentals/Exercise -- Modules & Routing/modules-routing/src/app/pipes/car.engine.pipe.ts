import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'engine'
})

export class EnginePipe implements PipeTransform {
    transform(value: string, countryCode: string) {
        switch (countryCode) {
            case 'BG':
                return value + ' КС';
            default:
                return value + ' HP';
        }
    }
}