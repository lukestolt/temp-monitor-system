import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
  })

export class TimeService {

    // expect the format of year-month-dayThour:minute
    createKey(dateTime: string): number {
        const year = dateTime.substring(0, 4);
        console.log('year = ' + year);
        const month = dateTime.substring(5, 7);
        console.log('month = ' + month);
        const day = dateTime.substring(8, 10);
        console.log('day = ' + day);
        const hour = dateTime.substring(11, 13);
        console.log('hour = ' + hour);
        const minute = dateTime.substring(14, 16);
        console.log('minute = ' + minute);

        const keyString = year + month + day + hour + minute + '00';
        const key = +keyString;
        console.log(key);
        return key;

    }
}
